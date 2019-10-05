using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionviewSourceSample
{

    public class TypeControl : HeaderedContentControl
    {
        static TypeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TypeControl), new FrameworkPropertyMetadata(typeof(TypeControl)));
        }

        public TypeControl()
        {
        
        }

        public override void OnApplyTemplate()
        {
            var comboBox = this.GetTemplateChild("cmbProperty") as ComboBox;
            buttonFilter = this.GetTemplateChild("buttonAppy") as Button;
            buttonClear = this.GetTemplateChild("btnClear") as Button;
            var textBox = this.GetTemplateChild("textBox") as TextBox;
            if (ShowValue == false)
                textBox.Visibility = Visibility.Collapsed;
            textBox.SelectionChanged += (a, e) => Value = textBox.Text;
            comboBox.SelectionChanged += (a, e) => Property = e.AddedItems.Cast<string>().First();
            buttonFilter.Click += ButtonFilter_Click;
            buttonClear.Click += ButtonClear_Click;
            comboBox.ItemsSource = Type.GetProperties().Select(a => a.Name);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            RaiseClearEvent();
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            RaiseApplyEvent();
        }



        public bool ShowValue
        {
            get { return (bool)GetValue(ShowValueProperty); }
            set { SetValue(ShowValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowValueProperty =
            DependencyProperty.Register("ShowValue", typeof(bool), typeof(TypeControl), new PropertyMetadata(true));



        public string Property
        {
            get { return (string)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Property.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.Register("Property", typeof(string), typeof(TypeControl), new PropertyMetadata(null));


        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Property.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(TypeControl), new PropertyMetadata(null));



        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =            DependencyProperty.Register("Type", typeof(Type), typeof(TypeControl), new PropertyMetadata(null));





        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent ApplyEvent = EventManager.RegisterRoutedEvent(
            "Apply", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TypeControl));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Apply
        {
            add { AddHandler(ApplyEvent, value); }
            remove { RemoveHandler(ApplyEvent, value); }
        }

        // This method raises the Apply event
        void RaiseApplyEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TypeControl.ApplyEvent);
            RaiseEvent(newEventArgs);
        }


        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent ClearEvent = EventManager.RegisterRoutedEvent(
            "Clear", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TypeControl));
        private ComboBox comboBox;
        private Button buttonFilter;
        private Button buttonClear;

        // Provide CLR accessors for the event
        public event RoutedEventHandler Clear
        {
            add { AddHandler(ClearEvent, value); }
            remove { RemoveHandler(ClearEvent, value); }
        }

        // This method raises the Clear event
        void RaiseClearEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TypeControl.ClearEvent);
            RaiseEvent(newEventArgs);
        }

    }


}
