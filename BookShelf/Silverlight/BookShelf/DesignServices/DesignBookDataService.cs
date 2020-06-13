using System;
using System.Collections.ObjectModel;
using OpenRiaServices.DomainServices.Client;
using BookShelf.Web.Models;
using MEFedMVVM.ViewModelLocator;
using BookShelf.Web.Services;
using Ria.Common;
using OpenRiaServices.Data.DomainServices;
using System.Collections.Generic;
using System.Windows;

namespace BookShelf
{
    [ExportService(ServiceType.DesignTime, typeof(IBookDataService))]
    public class DesignBookDataService : IBookDataService
    {
        private readonly EntityContainer _entityContainer = new BookClubContext.BookClubContextEntityContainer();

        public EntityContainer EntityContainer
        {
            get { return this._entityContainer; }
        }

        public void SubmitChanges(Action<ServiceSubmitChangesResult> callback, object state)
        {
            throw new NotImplementedException("SubmitChanges shouldn't be called at design-time.");
        }

        public void LoadBooksByCategory(int categoryId, QueryBuilder<Book> query, Action<ServiceLoadResult<Book>> callback, object state)
        {
            this.Load(query.ApplyTo(new DesignBooks()), callback, state);
        }

        public void LoadBooksOfTheDay(Action<ServiceLoadResult<BookOfDay>> callback, object state)
        {
            this.Load(new DesignBooksOfTheDay(), callback, state);
        }

        public void LoadCategories(Action<ServiceLoadResult<Category>> callback, object state)
        {
            this.Load(new DesignCategories(), callback, state);
        }

        public void LoadCheckouts(Action<ServiceLoadResult<Checkout>> callback, object state)
        {
            this.Load(new DesignCheckouts(), callback, state);
        }

        private void Load<T>(IEnumerable<T> entities, Action<ServiceLoadResult<T>> callback, object state) where T : Entity
        {
            this.EntityContainer.LoadEntities(entities);
            Deployment.Current.Dispatcher.BeginInvoke(() => callback(new ServiceLoadResult<T>(entities, state)));
        }
    }
}