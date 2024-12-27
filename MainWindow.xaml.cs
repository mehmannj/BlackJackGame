using BlackJackGame;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlackJackGame
{
    public partial class MainWindow : Window
    {
        BlackJackEngine game = new BlackJackEngine();

        public MainWindow()
        {
            InitializeComponent();
            game.Init();
            DealInitialCards();
            RefreshScreen();
        }

        private void DealInitialCards()
        {
            game.DealToPlayer();
            game.DealToPlayer();
            game.DealToDealer();
            game.DealToDealer();
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            game.DealToPlayer();
            RefreshScreen();
            if (game.getPlayerSum() > 21)
            {
                MessageBox.Show("Player busted. Game Over!!");
                ShowAllDealerCards();
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            game.DealToDealer();
            ShowAllDealerCards();

            int playerSum = game.getPlayerSum();
            int dealerSum = game.getDealerSum();

            if (dealerSum > 21 || playerSum > dealerSum)
            {
                MessageBox.Show("Player wins!");
            }
            else if (playerSum < dealerSum)
            {
                MessageBox.Show("Dealer wins!");
            }
            else
            {
                MessageBox.Show("It's a tie!");
            }
        }

        private void RefreshScreen()
        {
            PlayerPanel.Children.Clear();
            DealerPanel.Children.Clear();

            // Refresh player cards
            foreach (Card c in game.PlayerHand)
            {
                ShowCard(c.GetImageFilename(), PlayerPanel);
            }

            // Refresh dealer cards
            for (int i = 0; i < game.DealerHand.Count; i++)
            {
                if (i == 0)
                {
                    ShowCard(game.DealerHand[i].GetImageFilename(), DealerPanel);
                }
                else
                {
                    ShowCard("back.jpg", DealerPanel); 
                }
            }
        }

        private void ShowAllDealerCards()
        {
            DealerPanel.Children.Clear();
            foreach (Card c in game.DealerHand)
            {
                ShowCard(c.GetImageFilename(), DealerPanel);
            }
        }

        private void ShowCard(string filename, WrapPanel panel)
        {
            string path = "C:\\Users\\MANN\\source\\repos\\BlackJackGame\\BlackJackGame\\JPEG\\";
            BitmapImage bitmap = new BitmapImage(new Uri(path + filename));
            Image image = new Image();
            image.Source = bitmap;
            panel.Children.Add(image);
        }
    }
}
