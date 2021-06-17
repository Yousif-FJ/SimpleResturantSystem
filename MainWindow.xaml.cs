using SimpleResturantSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleResturantSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel viewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            var dises =  CodeDishesGenerator.GetDishes();
            viewModel = new ViewModel { Dishes = dises };
            DataContext = viewModel;
            GenerateDishesElement();
        }

        private void GenerateDishesElement()
        {
            foreach (var dish in viewModel.Dishes)
            {
                var stackPanelMain = new StackPanel();
                stackPanelMain.Margin = new Thickness(20, 20, 20, 20);

                var price = new TextBlock()
                {
                    FontSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = dish.Price.ToString()
                };
                stackPanelMain.Children.Add(price);

                var image = new Image()
                {
                    Source = new BitmapImage(new Uri(dish.PhotoUri)),
                    Height = 200,
                    Width = 200
                };
                stackPanelMain.Children.Add(image);

                var stackPanelButtons = new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10),
                };
                stackPanelMain.Children.Add(stackPanelButtons);

                var plusButton = new Button()
                {
                    Content = "+",
                    Width = 40,
                    FontSize = 32,
                    Margin = new Thickness(0, 0, 40, 0),
                    DataContext = dish
                };
                plusButton.Click += PlusButton_Click;
                stackPanelButtons.Children.Add(plusButton);

                var count = new TextBlock()
                {
                    FontSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = dish.Count.ToString(),
                    DataContext = dish
                };
                count.SetBinding(TextBlock.TextProperty, "Count");
                stackPanelButtons.Children.Add(count);

                var minusButton = new Button()
                {
                    Content = "-",
                    Width = 40,
                    FontSize = 32,
                    Margin = new Thickness(40, 0, 0, 0),
                    DataContext = dish
                };
                minusButton.Click += MinusButton_Click;
                stackPanelButtons.Children.Add(minusButton);

                DishesWrapPanel.Children.Add(stackPanelMain);
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            ++dish.Count;
            viewModel.Total +=dish.Price;    
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            if (viewModel.Total> 0)
            {
                --dish.Count;
                viewModel.Total -= dish.Price;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
        }
    }
}
