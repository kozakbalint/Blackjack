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

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool dealerCanHit = true;
        int bet;
        DealCards deal = new DealCards();
        Player player = new Player();
        public MainWindow()
        {
            InitializeComponent();
            standBtn.IsEnabled = false;
            hitBtn.IsEnabled = false;
        }

        private void Stand(object sender, RoutedEventArgs e)
        {
            hitBtn.IsEnabled = false;

            while (deal.calculateCardValue(false) < 17)
            {
                deal.DealCard(1, false);
                updateHand();
            }
            dealerCanHit = false;
            checkWin();
            betBtn.IsEnabled = true;
        }

        private void Hit(object sender, RoutedEventArgs e)
        {
            deal.DealCard(1, true);
            updateHand();
            checkWin();
        }

        private void Bet(object sender, RoutedEventArgs e)
        {
            if (betBalance())
            {
                deal.StartDeal();
                output.Content = "Output:";
                updateHand();
                betBtn.IsEnabled = false;
                hitBtn.IsEnabled = true;
                standBtn.IsEnabled = true;
                checkWin();
            }
        }

        private void PlayerNameChanged(object sender, TextChangedEventArgs e)
        {
            player.SetName = playerNameInput.Text;
            playerLabel.Content = $"Player Name: {player.GetName}";
        }

        private void BalanceChanged(object sender, TextChangedEventArgs e)
        {
            int balance;
            try
            {
                balance = Int32.Parse(balanceInput.Text);
                player.SetBalance = balance;
                updateBalance();
            }
            catch (Exception)
            {
                MessageBox.Show("Számot addj meg.");
            }
        }

        private void ClearHistory(object sender, RoutedEventArgs e)
        {
            history.Items.Clear();
            player.ClearResult();
        }

        public void updateHand()
        {
            playerHandListBox.Items.Clear();
            dealerHandListBox.Items.Clear();
            foreach (var item in deal.GetPlayerHand)
            {
                playerHandListBox.Items.Add(item.MyValue + " of " + item.MySuit);
            }
            foreach (var item in deal.GetDealerHand)
            {
                dealerHandListBox.Items.Add(item.MyValue + " of " + item.MySuit);
            }
            playerCardValueLabel.Content = deal.calculateCardValue(true);
            dealerCardValueLabel.Content = deal.calculateCardValue(false);
        }

        public void checkWin()
        {
            int playerValue = deal.calculateCardValue(true);
            int dealerValue = deal.calculateCardValue(false);
            List<Card> playerHand = deal.GetPlayerHand;
            List<Card> dealerHand = deal.GetDealerHand;

            if (playerValue > 21)
            {
                string msg = "You busted. Dealer won.";
                output.Content = $"Output: {msg}";
                AddResultEntry(msg);
                resetDeal();
            }
            else if (dealerValue > 21)
            {
                string msg = "Dealer busted. You won.";
                output.Content = $"Output: {msg}";
                player.SetBalance = player.GetBalance + bet * 2;
                updateBalance();
                AddResultEntry(msg);
                resetDeal();
            }
            else if (playerValue == dealerValue && !dealerCanHit)
            {
                string msg = "Push";
                output.Content = $"Output: {msg}";
                player.SetBalance = player.GetBalance + bet;
                updateBalance();
                AddResultEntry(msg);
                resetDeal();
            }
            else if (playerHand.Where(x => x.MyValue == Card.VALUE.ACE).Count() == 1 && (playerHand.Where(x => x.MyValue == Card.VALUE.TEN).Count() == 1 || playerHand.Where(x => x.MyValue == Card.VALUE.QUEEN).Count() == 1 || playerHand.Where(x => x.MyValue == Card.VALUE.KING).Count() == 1 || playerHand.Where(x => x.MyValue == Card.VALUE.JACK).Count() == 1) && playerHand.Count == 2)
            {
                string msg = "Player'd a Blackjack.";
                output.Content = $"Output: {msg}";
                player.SetBalance = player.GetBalance + bet * 2 + bet / 2;
                updateBalance();
                AddResultEntry(msg);
                resetDeal();
            }
            else if (dealerHand.Where(x => x.MyValue == Card.VALUE.ACE).Count() == 1 && (dealerHand.Where(x => x.MyValue == Card.VALUE.TEN).Count() == 1 || dealerHand.Where(x => x.MyValue == Card.VALUE.QUEEN).Count() == 1 || dealerHand.Where(x => x.MyValue == Card.VALUE.KING).Count() == 1 || dealerHand.Where(x => x.MyValue == Card.VALUE.JACK).Count() == 1) && playerHand.Count == 2)
            {
                string msg = "Dealer'd a Blackjack.";
                output.Content = $"Output: {msg}";
                AddResultEntry(msg);
                resetDeal();
            }
            else if (playerValue == 21)
            {
                Stand(null,null);
            }
            else if (playerValue > dealerValue && !dealerCanHit)
            {
                string msg = "You won, you were closer to 21.";
                output.Content = $"Output: {msg}";
                player.SetBalance = player.GetBalance + bet * 2;
                updateBalance();
                AddResultEntry(msg);
                resetDeal();
            }
            else if (playerValue < dealerValue && !dealerCanHit)
            {
                string msg = "You lost, the dealer was closer to 21.";
                output.Content = $"Output: {msg}";
                AddResultEntry(msg);
                resetDeal();
            }
        }

        public bool betBalance()
        {
            try
            {
                bet = Int32.Parse(betInput.Text);
                if (bet < player.GetBalance)
                {
                    player.SetBalance = player.GetBalance - bet;
                    updateBalance();

                    return true;
                }
                else
                {
                    MessageBox.Show("Nincs elég pénzed.");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Valid értéket addj meg.");
                return false;
            }

        }

        public void updateBalance()
        {
            balanceLabel.Content = $"Balance: {player.GetBalance}";
            balanceInput.Text = player.GetBalance.ToString();
        }

        public void resetDeal()
        {
            deal.ClearDealerHand();
            deal.ClearPlayerHand();
            dealerCanHit = true;
            hitBtn.IsEnabled = false;
            standBtn.IsEnabled = false;
            betBtn.IsEnabled = true;
        }

        public void AddResultEntry(string msg)
        {
            Result entry = new Result(msg, deal.GetPlayerHand, deal.GetPlayerHand);
            player.SetResult = entry;
            history.Items.Add($"{msg}");
        }
    }
}
