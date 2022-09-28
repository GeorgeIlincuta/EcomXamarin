using EcomXamarin.Models;
using EcomXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcomXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersDetailPage : ContentPage
    {
        public ObservableCollection<Order> OrderDetail;
        public OrdersDetailPage()
        {
            InitializeComponent();
            OrderDetail = new ObservableCollection<Order>();
            GetOrderDetails();
        }

        private async void GetOrderDetails()
        {
            var orders = await ApiService.GetOrderDetails(Preferences.Get("userId", 0));
            foreach (var order in orders)
            {
                OrderDetail.Add(order);
            }
            LvOrderDetail.ItemsSource = OrderDetail;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}