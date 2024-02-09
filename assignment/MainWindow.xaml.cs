using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static assignment.Type;
using System.IO;

namespace assignment
{
    public partial class MainWindow : Window
    {
        private int currentPage = 1;
        public List<int> previouslyloadedpage = new List<int>();
        string fileName = $"productData.json";
        public MainWindow()
        {
            InitializeComponent();
            LoadDataAndDisplay();
        }
        // Function to Check if there is internet connected 
        private static bool IsInternetConnected()
        {
            try
            {
                using (var client = new System.Net.NetworkInformation.Ping())
                {
                    var result = client.Send("www.google.com");
                    return result.Status == System.Net.NetworkInformation.IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        // Loading data into the App Window
        private void LoadDataAndDisplay()
        {

            var restSharpHelper = new RestSharpHelper();
            var getProductData = restSharpHelper.getProductDataPerPage(currentPage);
            List<ProductToShow> productData = new List<ProductToShow>();
            // IF internet is connected fetch new data from API 
            if (IsInternetConnected())
            {
                foreach (var item in getProductData.Data)
                {
                    productData.Add(new ProductToShow
                    {
                        Name = item.name,
                        Type = item.type,
                        RegularPrice = item.variations != null && item.variations.Count > 0
                            ? "RM" + (item.variations[0].regular_price?.ToString() ?? "10")
                            : "RM10",
                        Options = item.attributes != null && item.attributes.Count > 0 &&
                                   item.attributes[0]["options"] != null
                            ? item.attributes[0]["options"].ToObject<string[]>() ?? new string[0]
                            : new[] { "Piece" },
                        Id = item.id,
                        ImagePath = item.images[0].src
                    });
                    fileName = $"productData{currentPage}.json";
                    string json = JsonSerializer.Serialize(productData, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(fileName, json);
                }
            }

            // IF no Interent connection then load previously loaded data 
            else
            {
                System.Diagnostics.Debug.WriteLine("No WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
                System.Diagnostics.Debug.WriteLine(currentPage);
                fileName = $"productData{currentPage}.json";
                string json = File.ReadAllText(fileName);
                productData = JsonSerializer.Deserialize<List<ProductToShow>>(json);
            }


                if (productData != null)
            {
               

               

                foreach (var product in productData)
                {
                    // Create UI elements for each product
                    StackPanel productPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5), HorizontalAlignment = HorizontalAlignment.Left };
                    TextBlock nameTextBlock = new TextBlock
                    {
                        Text = product.Name,
                        Width = this.Width * 0.85,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        FontFamily = new FontFamily("Kobern"), // Set the font family to Kobern
                        FontSize = 12, // Set the font size (adjust as needed)
                        FontWeight = FontWeights.Bold // Set the font weight to bold
                    };
                    StackPanel StackPanel1 = new StackPanel { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Stretch };
                    StackPanel StackPanel2 = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment  = HorizontalAlignment.Right };
                    StackPanel StackPanel3 = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Stretch };
                    StackPanel StackPanel4 = new StackPanel { Orientation = Orientation.Horizontal };
                    TextBlock idTextBlock = new TextBlock
                    {
                        Text = product.Id.ToString(),
                        Padding = new Thickness(0, 0, 0, 5),
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Foreground = Brushes.Gray // Set the font color to gray
                    };
                    TextBlock priceTextBlock = new TextBlock { Text = product.RegularPrice.ToString(), HorizontalAlignment = HorizontalAlignment.Left };
                    ComboBox combobox = new ComboBox { Width= this.Width * 0.70, Height = 25, HorizontalAlignment = HorizontalAlignment.Left };

                    foreach (var item in product.Options)
                    {
                        combobox.Items.Add(item);
                    }

                    combobox.SelectedIndex = 0;

                    Image productImage = new Image
                    {
                        Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Absolute)),
                        Width = 70,
                        Height = 70,
                        Margin = new Thickness(5),
                        HorizontalAlignment = HorizontalAlignment.Right
                    };

                    Button addToCartButton = new Button
                    {
                        Content = " Add to Cart ",
                        Height = 20,
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3275b9")),
                        Foreground = Brushes.White,
                        HorizontalAlignment = HorizontalAlignment.Left
                    };

                    Button addToCartbasket = new Button
                    {
                        Margin = new Thickness(7,0,0,0),
                        Width = 25,
                        Height = 20,
                        Background = Brushes.White
                    };

                    Image addToCartButtonImage = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/basket1.png")), 
                        Width = 20,
                        Height = 20
                    };

                 
                    // Set the Image as the Content of the Button
                    addToCartbasket.Content = addToCartButtonImage;

                    Button plusebutton = new Button
                    {
                        Content = "+",
                        Width = 20,
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#82be3a")),
                        Foreground = Brushes.White,
                        Height = 20,
                        Margin = new Thickness(5, 0, 3, 0)
                    };

                    TextBox amount = new TextBox
                    {
                        Text = "1",
                        Width = 45,
                        Height = 20,
                    };

                    Button minusbutton = new Button
                    {
                        Content = "-",
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#82be3a")),
                        Foreground = Brushes.White,
                        Width = 20,
                        Margin = new Thickness(3, 0, 0, 0),
                        Height = 20,
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#82be3a")),
                        BorderThickness = new Thickness(1), // Set the border thickness
                        FontWeight = FontWeights.Bold,
                    };

                    TextBlock uomTextBlock = new TextBlock
                    {
                        Text = "Uom",
                        HorizontalAlignment = HorizontalAlignment.Left,
                        FontFamily = new FontFamily("Kobern"), // Set the font family to Kobern
                        Foreground = Brushes.Gray, // Set the font color to gray
                        Padding = new Thickness(0, 0, 0, 5) // Set padding to the bottom (adjust as needed)
                    };

                    // Event handlers for plus and minus buttons
                    plusebutton.Click += (s, e) => IncreaseAmount(amount);
                    minusbutton.Click += (s, e) => DecreaseAmount(amount);
                    StackPanel1.Children.Add(nameTextBlock);
                    StackPanel1.Children.Add(idTextBlock);
                    StackPanel1.Children.Add(priceTextBlock);
                    StackPanel2.Children.Add(productImage);
                    StackPanel3.Children.Add(StackPanel1);
                    StackPanel3.Children.Add(StackPanel2);
                    StackPanel4.Children.Add(combobox);
                    StackPanel4.Children.Add(plusebutton);
                    StackPanel4.Children.Add(amount);
                    StackPanel4.Children.Add(minusbutton);
                    StackPanel4.Children.Add(addToCartbasket);
                    StackPanel4.Children.Add(addToCartButton);
                    productPanel.Children.Add(StackPanel3);
                    productPanel.Children.Add(uomTextBlock);
                    productPanel.Children.Add(StackPanel4);
                    MainStackPanel.Children.Add(productPanel);
                }
            }
            else
            {
                MessageBox.Show("No data available for the current page.");
            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Add the item to the cart
            // Update the total cost
        }

        private void LoadNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear existing items in the MainStackPanel
            MainStackPanel.Children.Clear();

            // Increment the currentPage variable
            if (IsInternetConnected() || previouslyloadedpage.Contains(currentPage + 1))
                currentPage++;

            if (!previouslyloadedpage.Contains(currentPage))
                previouslyloadedpage.Add(currentPage);

            // Load data and display for the next page
            LoadDataAndDisplay();
        }

        private void LoadPreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear existing items in the MainStackPanel
            MainStackPanel.Children.Clear();

            // Decrement the currentPage variable (ensure it doesn't go below 1)
            currentPage = Math.Max(1, currentPage - 1);

            // Load data and display for the previous page
            LoadDataAndDisplay();
        }
        // Event Heandler to increase the Amount 
        private void IncreaseAmount(TextBox textBox)
        {
            int currentAmount;
            if (int.TryParse(textBox.Text, out currentAmount))
            {
                currentAmount++;
                textBox.Text = currentAmount.ToString();
            }
        }
        // Event Heandler to decrease the Amount 
        private void DecreaseAmount(TextBox textBox)
        {
            int currentAmount;
            if (int.TryParse(textBox.Text, out currentAmount) && currentAmount > 1)
            {
                currentAmount--;
                textBox.Text = currentAmount.ToString();
            }
        }
    }
}