using SimpleResturantSystem.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SimpleResturantSystem
{
    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            var dises = CodeDishesGenerator.GetDishes();
            ViewModel = new ViewModel { Dishes = dises };
            DataContext = ViewModel;
            GenerateDishesElement();
        }

        private void GenerateDishesElement()
        {
            foreach (var dish in ViewModel.Dishes)
            {
                var stackPanelMain = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(20, 20, 20, 20)
                };

                var price = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 24,
                    Text = dish.Price.ToString()
                };

                try
                {
                    var image = new Image()
                    {
                        Source = new BitmapImage(new Uri(dish.PhotoUri)),
                        Height = 220,
                        Width = 220
                    };
                    stackPanelMain.Children.Add(image);
                }
                catch (Exception)
                {
                    var errorMessage = new TextBlock() { Text = "Picture is not found" };
                    stackPanelMain.Children.Add(errorMessage);
                }

                var stackPanelButtons = new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10),
                };

                var plusButton = CreateMinusPlusButton(dish, "+");
                plusButton.Click += PlusButton_Click;

                var count = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 24,
                    Text = dish.Count.ToString(),
                    DataContext = dish
                };
                count.SetBinding(TextBlock.TextProperty, "Count");

                var minusButton = CreateMinusPlusButton(dish, "-");
                minusButton.Click += MinusButton_Click;

                stackPanelMain.Children.Add(price);
                stackPanelMain.Children.Add(stackPanelButtons);
                stackPanelButtons.Children.Add(plusButton);
                stackPanelButtons.Children.Add(count);
                stackPanelButtons.Children.Add(minusButton);
                DishesWrapPanel.Children.Add(stackPanelMain);
            }
        }

        private static Button CreateMinusPlusButton(Dish dish, string plusOrMinus)
        {
            return new Button()
            {
                Content = plusOrMinus,
                Width = 40,
                FontSize = 32,
                Margin = new Thickness(20, 0, 20, 0),
                DataContext = dish
            };
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            ++dish.Count;
            ViewModel.Total += dish.Price;
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            if (ViewModel.Total > 0)
            {
                --dish.Count;
                ViewModel.Total -= dish.Price;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Reset();
        }
    }
}
