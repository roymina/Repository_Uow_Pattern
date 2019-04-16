using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _dataContext;
        private IBlogRepository _blogRepository;

        public RepositoryWrapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IBlogRepository Blog
        {
            get
            {
                if (_blogRepository is null)
                {
                    _blogRepository = new BlogRepository(_dataContext);
                }
                return _blogRepository;
            }
        }
    }
}
