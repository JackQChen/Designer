using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessControl
{

    /// <summary>
    /// Simple service interface
    /// </summary>
    public interface IServiceProvider
    {
        IEditorService EditorService { get; }
        IMessageBoxService MessageBoxService { get; }
        IStorageService StorageService { get; }
    }


    /// <summary>
    /// Simple service locator
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        private IEditorService editorService = new WPFEditorService();
        private IMessageBoxService messageBoxService = new WPFMessageBoxService();
        private IStorageService storageService = new WPFStorageService();

        public IEditorService EditorService
        {
            get { return editorService; }
        }

        public IMessageBoxService MessageBoxService
        {
            get { return messageBoxService; }
        }

        public IStorageService StorageService
        {
            get { return storageService; }
        }

    }

    /// <summary>
    /// Simple service locator helper
    /// </summary>
    public class ApplicationServicesProvider
    {
        private static Lazy<ApplicationServicesProvider> instance = new Lazy<ApplicationServicesProvider>(() => new ApplicationServicesProvider());
        private IServiceProvider serviceProvider = new ServiceProvider();

        private ApplicationServicesProvider()
        {

        }

        static ApplicationServicesProvider()
        {

        }

        public void SetNewServiceProvider(IServiceProvider provider)
        {
            serviceProvider = provider;
        }

        public IServiceProvider Provider
        {
            get { return serviceProvider; }
        }

        public static ApplicationServicesProvider Instance
        {
            get { return instance.Value; }
        }
    }
}
