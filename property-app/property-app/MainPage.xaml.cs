using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace property_app
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<PropertyType> PropertyTypeList => GetPropertyTypes();
        public List<Property> PropertyList => GetProperties();

        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType{TypeName="All"},
                new PropertyType{TypeName="Studio"},
                new PropertyType{TypeName="4 Bed"},
                new PropertyType{TypeName="3 Bed"},
                new PropertyType{TypeName="Office"},
            };
        }
        private List<Property> GetProperties()
        {
            return new List<Property>
            {
                new Property{Image="apt1.png", Address = "2162 Patricia Ave, LA", Location="California", Price="$1500/month", Bed="4 Bed", Bath="3 Bath", Space="1600 sqft", Details="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."},
                new Property{Image="apt2.png", Address = "2168 Cushions Dr, LA", Location="California", Price="$1000/month", Bed="3 Bed", Bath="1 Bath", Space="1100 sqft", Details="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."},
                new Property{Image="apt3.png", Address = "2112 Anthony Way, LA", Location="California", Price="$900/month", Bed="2 Bed", Bath="2 Bath", Space="1200 sqft", Details="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."},
            };
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private void SelectType(object sender, EventArgs e)
        {
            View view = sender as View;
            StackLayout parent = view as StackLayout;

            foreach(View child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var textControl = child.FindByName<Label>("PropertyTypeName");

            if(textControl != null)
            {
                textControl.TextColor = Color.FromHex(hexColor);
            }
        }
    }

    public class PropertyType
    {
        public string TypeName { get; set; }
    }

    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
    }
}
