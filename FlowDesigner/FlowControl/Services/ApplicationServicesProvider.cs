using System;

namespace FlowControl
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
    /// Simple service locator helper
    /// </summary>
    public class ApplicationServicesProvider
    {
        private static Lazy<ApplicationServicesProvider> instance = new Lazy<ApplicationServicesProvider>(() => new ApplicationServicesProvider());
        private IServiceProvider serviceProvider;

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
