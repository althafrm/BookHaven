using BookHaven.Forms.Authentication;
using BookHaven.Forms.Dashboard;
using BookHaven.Repositories;
using BookHaven.Services;
using BookHaven.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace BookHaven
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //IBookService bookService = new BookService(new BookRepository());
            //Application.Run(new Dashboard(bookService));

            //Login loginForm = new Login();
            //Application.Run(loginForm);
            //if (!string.IsNullOrEmpty(SessionManager.LoggedInUser))
            //{
            //    Application.Run(new Dashboard(bookService));
            //}

            var services = new ServiceCollection();

            // Register Repositories
            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IBookGenreRepository, BookGenreRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ISupplierRepository, SupplierRepository>();
            services.AddSingleton<ISalesRepository, SalesRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            // Register Services
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IBookGenreService, BookGenreService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ISupplierService, SupplierService>();
            services.AddSingleton<ISalesService, SalesService>();
            services.AddSingleton<IOrderService, OrderService>();

            // Build Dependency Injection Container
            var serviceProvider = services.BuildServiceProvider();

            // Show Login Form First
            var loginForm = new Login(serviceProvider);
            Application.Run(loginForm);
        }
    }
}