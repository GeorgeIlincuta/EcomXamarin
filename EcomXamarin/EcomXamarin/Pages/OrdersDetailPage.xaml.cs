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
        public ObservableCollection<OrderDetail> OrderDetail;
        public OrdersDetailPage(int orderId)
        {
            InitializeComponent();
            OrderDetail = new ObservableCollection<OrderDetail>();
            GetOrderDetails(orderId);
        }

        private async void GetOrderDetails(int orderId)
        {
            var orders = await ApiService.GetOrderDetails(orderId);
            OrderDetail test = new OrderDetail();
            foreach (var order in orders)
            {   
                test.id = order.orderDetails.Select(x => x.id).FirstOrDefault();
                test.price = order.orderDetails.Select(x => x.price).FirstOrDefault();
                test.qty = order.orderDetails.Select(x => x.qty).FirstOrDefault();
                test.totalAmount = order.orderDetails.Select(x => x.totalAmount).FirstOrDefault();
                test.orderId = order.orderDetails.Select(x => x.orderId).FirstOrDefault();
                test.productId = order.orderDetails.Select(x => x.productId).FirstOrDefault();
                test.product = order.orderDetails.Select(x => x.product).FirstOrDefault();
                 
                OrderDetail.Add(test);
            }
            LvOrderDetail.ItemsSource = OrderDetail;
            LblTotalPrice.Text = orders.Select(x => x.id).FirstOrDefault().ToString();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}