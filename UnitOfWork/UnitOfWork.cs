using School_Management_System.Interfaces;
using School_Management_System.Models;
using School_Management_System.Repository;

namespace School_Management_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly SmsdbContext _smsdbContext;

        public IRepository<Student> Students { get; }

        public IRepository<Enrollment> Enrollments { get; }

        public IRepository<Course> Courses { get; }

        public UnitOfWork(SmsdbContext smsdbContext)
        {
            _smsdbContext = smsdbContext;
            Students = new Repository<Student>(_smsdbContext);
            Courses = new Repository<Course>(_smsdbContext);
            Enrollments = new Repository<Enrollment>(_smsdbContext);
        }

        public async Task Save()
        {
            await _smsdbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
