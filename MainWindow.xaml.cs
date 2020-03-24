using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Set {
    public partial class MainWindow : Window {
        private List<BoardPosition> board;
        private List<Card> deck;
        private int[] deckOrder;
        private int currentDeckPosition;
        private bool allowInteraction = true;
        private List<int> selectedBoardPositions;
        private int[] scoreboard;

        //Initialize
        public MainWindow() {
            InitializeComponent();
            CreateBoard();
            CreateDeck();
            NewGame();  
        }
        private void CreateBoard() {
            board = new List<BoardPosition> {
                new BoardPosition(A1), new BoardPosition(A2), new BoardPosition(A3), new BoardPosition(A4) , new BoardPosition(A5),
                new BoardPosition(B1), new BoardPosition(B2), new BoardPosition(B3), new BoardPosition(B4) , new BoardPosition(B5),
                new BoardPosition(C1), new BoardPosition(C2), new BoardPosition(C3), new BoardPosition(C4) , new BoardPosition(C5)
            };
        }
        private void CreateDeck() {
            deck = new List<Card> {
                new Card("Resources/bce1.jpg", "Resources/bce1_2.jpg", "bce1"), new Card("Resources/bce2.jpg", "Resources/bce2_2.jpg", "bce2"), new Card("Resources/bce3.jpg", "Resources/bce3_2.jpg", "bce3"),
                new Card("Resources/bcr1.jpg", "Resources/bcr1_2.jpg", "bcr1"), new Card("Resources/bcr2.jpg", "Resources/bcr2_2.jpg", "bcr2"), new Card("Resources/bcr3.jpg", "Resources/bcr3_2.jpg", "bcr3"),
                new Card("Resources/bcs1.jpg", "Resources/bcs1_2.jpg", "bcs1"), new Card("Resources/bcs2.jpg", "Resources/bcs2_2.jpg", "bcs2"), new Card("Resources/bcs3.jpg", "Resources/bcs3_2.jpg", "bcs3"),
                new Card("Resources/bde1.jpg", "Resources/bde1_2.jpg", "bde1"), new Card("Resources/bde2.jpg", "Resources/bde2_2.jpg", "bde2"), new Card("Resources/bde3.jpg", "Resources/bde3_2.jpg", "bde3"),
                new Card("Resources/bdr1.jpg", "Resources/bdr1_2.jpg", "bdr1"), new Card("Resources/bdr2.jpg", "Resources/bdr2_2.jpg", "bdr2"), new Card("Resources/bdr3.jpg", "Resources/bdr3_2.jpg", "bdr3"),
                new Card("Resources/bds1.jpg", "Resources/bds1_2.jpg", "bds1"), new Card("Resources/bds2.jpg", "Resources/bds2_2.jpg", "bds2"), new Card("Resources/bds3.jpg", "Resources/bds3_2.jpg", "bds3"),
                new Card("Resources/bse1.jpg", "Resources/bse1_2.jpg", "bse1"), new Card("Resources/bse2.jpg", "Resources/bse2_2.jpg", "bse2"), new Card("Resources/bse3.jpg", "Resources/bse3_2.jpg", "bse3"),
                new Card("Resources/bsr1.jpg", "Resources/bsr1_2.jpg", "bsr1"), new Card("Resources/bsr2.jpg", "Resources/bsr2_2.jpg", "bsr2"), new Card("Resources/bsr3.jpg", "Resources/bsr3_2.jpg", "bsr3"),
                new Card("Resources/bss1.jpg", "Resources/bss1_2.jpg", "bss1"), new Card("Resources/bss2.jpg", "Resources/bss2_2.jpg", "bss2"), new Card("Resources/bss3.jpg", "Resources/bss3_2.jpg", "bss3"),

                new Card("Resources/gce1.jpg", "Resources/gce1_2.jpg", "gce1"), new Card("Resources/gce2.jpg", "Resources/gce2_2.jpg", "gce2"), new Card("Resources/gce3.jpg", "Resources/gce3_2.jpg", "gce3"),
                new Card("Resources/gcr1.jpg", "Resources/gcr1_2.jpg", "gcr1"), new Card("Resources/gcr2.jpg", "Resources/gcr2_2.jpg", "gcr2"), new Card("Resources/gcr3.jpg", "Resources/gcr3_2.jpg", "gcr3"),
                new Card("Resources/gcs1.jpg", "Resources/gcs1_2.jpg", "gcs1"), new Card("Resources/gcs2.jpg", "Resources/gcs2_2.jpg", "gcs2"), new Card("Resources/gcs3.jpg", "Resources/gcs3_2.jpg", "gcs3"),
                new Card("Resources/gde1.jpg", "Resources/gde1_2.jpg", "gde1"), new Card("Resources/gde2.jpg", "Resources/gde2_2.jpg", "gde2"), new Card("Resources/gde3.jpg", "Resources/gde3_2.jpg", "gde3"),
                new Card("Resources/gdr1.jpg", "Resources/gdr1_2.jpg", "gdr1"), new Card("Resources/gdr2.jpg", "Resources/gdr2_2.jpg", "gdr2"), new Card("Resources/gdr3.jpg", "Resources/gdr3_2.jpg", "gdr3"),
                new Card("Resources/gds1.jpg", "Resources/gds1_2.jpg", "gds1"), new Card("Resources/gds2.jpg", "Resources/gds2_2.jpg", "gds2"), new Card("Resources/gds3.jpg", "Resources/gds3_2.jpg", "gds3"),
                new Card("Resources/gse1.jpg", "Resources/gse1_2.jpg", "gse1"), new Card("Resources/gse2.jpg", "Resources/gse2_2.jpg", "gse2"), new Card("Resources/gse3.jpg", "Resources/gse3_2.jpg", "gse3"),
                new Card("Resources/gsr1.jpg", "Resources/gsr1_2.jpg", "gsr1"), new Card("Resources/gsr2.jpg", "Resources/gsr2_2.jpg", "gsr2"), new Card("Resources/gsr3.jpg", "Resources/gsr3_2.jpg", "gsr3"),
                new Card("Resources/gss1.jpg", "Resources/gss1_2.jpg", "gss1"), new Card("Resources/gss2.jpg", "Resources/gss2_2.jpg", "gss2"), new Card("Resources/gss3.jpg", "Resources/gss3_2.jpg", "gss3"),

                new Card("Resources/rce1.jpg", "Resources/rce1_2.jpg", "rce1"), new Card("Resources/rce2.jpg", "Resources/rce2_2.jpg", "rce2"), new Card("Resources/rce3.jpg", "Resources/rce3_2.jpg", "rce3"),
                new Card("Resources/rcr1.jpg", "Resources/rcr1_2.jpg", "rcr1"), new Card("Resources/rcr2.jpg", "Resources/rcr2_2.jpg", "rcr2"), new Card("Resources/rcr3.jpg", "Resources/rcr3_2.jpg", "rcr3"),
                new Card("Resources/rcs1.jpg", "Resources/rcs1_2.jpg", "rcs1"), new Card("Resources/rcs2.jpg", "Resources/rcs2_2.jpg", "rcs2"), new Card("Resources/rcs3.jpg", "Resources/rcs3_2.jpg", "rcs3"),
                new Card("Resources/rde1.jpg", "Resources/rde1_2.jpg", "rde1"), new Card("Resources/rde2.jpg", "Resources/rde2_2.jpg", "rde2"), new Card("Resources/rde3.jpg", "Resources/rde3_2.jpg", "rde3"),
                new Card("Resources/rdr1.jpg", "Resources/rdr1_2.jpg", "rdr1"), new Card("Resources/rdr2.jpg", "Resources/rdr2_2.jpg", "rdr2"), new Card("Resources/rdr3.jpg", "Resources/rdr3_2.jpg", "rdr3"),
                new Card("Resources/rds1.jpg", "Resources/rds1_2.jpg", "rds1"), new Card("Resources/rds2.jpg", "Resources/rds2_2.jpg", "rds2"), new Card("Resources/rds3.jpg", "Resources/rds3_2.jpg", "rds3"),
                new Card("Resources/rse1.jpg", "Resources/rse1_2.jpg", "rse1"), new Card("Resources/rse2.jpg", "Resources/rse2_2.jpg", "rse2"), new Card("Resources/rse3.jpg", "Resources/rse3_2.jpg", "rse3"),
                new Card("Resources/rsr1.jpg", "Resources/rsr1_2.jpg", "rsr1"), new Card("Resources/rsr2.jpg", "Resources/rsr2_2.jpg", "rsr2"), new Card("Resources/rsr3.jpg", "Resources/rsr3_2.jpg", "rsr3"),
                new Card("Resources/rss1.jpg", "Resources/rss1_2.jpg", "rss1"), new Card("Resources/rss2.jpg", "Resources/rss2_2.jpg", "rss2"), new Card("Resources/rss3.jpg", "Resources/rss3_2.jpg", "rss3")
            };
        }

        //Start new game
        private void NewGame() {
            currentDeckPosition = 0;
            selectedBoardPositions = new List<int>();
            scoreboard = new int[] { 0, 0, 0, 0 };
            deckOrder = GetNewShuffledDeckOrder();
            Deal(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
        }
        private int[] GetNewShuffledDeckOrder() {
            Random r = new Random();
            int[] order = {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26,
                27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53,
                54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
            };

            for (int i = order.Length - 1; i > 0; i--) {
                int j = r.Next(0, i) % (i + 1);
                int temp = order[i];
                order[i] = order[j];
                order[j] = temp;
            }

            return order;
        }
        private void FinishGame() {
            new ResultWindow(scoreboard) { Owner = this }.ShowDialog();
            Restart();
        }
        private async void Restart() {
            allowInteraction = false;
            foreach (BoardPosition boardPosition in board)
                if (boardPosition.heldCard != null) {
                    await Task.Delay(75);
                    boardPosition.TakeCard();
                }
            NewGame();
        }

        //Deal cards
        private async void Deal(List<int> boardPositions) {
            allowInteraction = false;
            foreach (int bp in boardPositions) {
                await Task.Delay(200);
                Card nextCard = GetNextCardFromDeck();
                board[bp].HoldCard(nextCard);
            }
            selectedBoardPositions.Clear();
            allowInteraction = true;
            AICheckSet();
        }
        private Card GetNextCardFromDeck() {
            if (currentDeckPosition < deck.Count)
                return deck[deckOrder[currentDeckPosition++]];
            return null;
        }
        private async void TakeSelectedCards() {
            foreach (int boardPosition in selectedBoardPositions) {
                await Task.Delay(200);
                board[boardPosition].TakeCard();
            }
            Deal(selectedBoardPositions);
        }
        private void UnselectSelectedCards() {
            foreach (int boardPosition in selectedBoardPositions)
                board[boardPosition].PressCard();
            selectedBoardPositions.Clear();
            allowInteraction = true;
        }

        //Check if set
        private void UpdateSet(int boardPosition) {
            if (board[boardPosition].heldCard != null)
                if (!selectedBoardPositions.Contains(boardPosition))
                    selectedBoardPositions.Add(boardPosition);
                else 
                    selectedBoardPositions.Remove(boardPosition);
        }
        private bool CheckSet(int boardPosition1, int boardPosition2, int boardPosition3) {
            char[] idCard1 = board[boardPosition1].heldCard.id.ToCharArray();
            char[] idCard2 = board[boardPosition2].heldCard.id.ToCharArray();
            char[] idCard3 = board[boardPosition3].heldCard.id.ToCharArray();

            bool foundSet = true;
            for (int i = 0; i < 4; i++)
                if (!(
                    idCard1[i] == idCard2[i] && idCard2[i] == idCard3[i] ||
                    idCard1[i] != idCard2[i] && idCard2[i] != idCard3[i] && idCard3[i] != idCard1[i]
                    )) {
                    foundSet = false;
                    break;
                }

            return foundSet;
        }
        private void AICheckSet() {
            bool setExists = false;
            for (int a = 0; a < board.Count - 2; a++)
                if (setExists)
                    break;
                else if (board[a].heldCard == null)
                    continue;
                else
                    for (int b = a + 1; b < board.Count - 1; b++)
                        if (setExists)
                            break;
                        else if (board[b].heldCard == null)
                            continue;
                        else
                            for (int c = b + 1; c < board.Count; c++)
                                if (board[c].heldCard != null && CheckSet(a, b, c)) {
                                    setExists = true;
                                    break;
                                }
            if (!setExists)
                FinishGame();
        }
        private void UpdateScoreboard(bool set) {
            int player = GetPlayer();
            if (player != -1)
                if (set) {
                    scoreboard[player]++;
                    TakeSelectedCards();
                } else {
                    scoreboard[player] = 0;
                    new RedWindow { Owner = this }.ShowDialog();
                    UnselectSelectedCards();
                }
            else
                UnselectSelectedCards();
        }
        private int GetPlayer() {
            SelectPlayerWindow spw = new SelectPlayerWindow() { Owner = this };
            if (spw.ShowDialog() == true)
                return spw.player;
            return -1;
        }

        //Click events
        private void Table_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (allowInteraction) {
                Point p = Mouse.GetPosition(Table);
                int col = 0, row = 0;
                double accHeight = 0, accWidth = 0;

                foreach (ColumnDefinition c in Table.ColumnDefinitions) {
                    accWidth += c.ActualWidth;
                    if (accWidth >= p.X)
                        break;
                    col++;
                }

                foreach (RowDefinition r in Table.RowDefinitions) {
                    accHeight += r.ActualHeight;
                    if (accHeight >= p.Y)
                        break;
                    row++;
                }

                if (col % 2 == 0 || row % 2 == 0)
                    ShowPauseWindow();
                else if (selectedBoardPositions.Count < 3) {
                    col -= col / 2 + 1;
                    row -= row / 2 + 1;
                    PressCard(col + 5 * row);
                }
            }
        }
        private void ShowPauseWindow() {
            PauseWindow pw = new PauseWindow { Owner = this };
            pw.ShowDialog();
            switch (pw.decision) {
                case "finish":
                    FinishGame();
                    break;
                case "restart":
                    Restart();
                    break;
                case "quit":
                    Close();
                    break;
                default:
                    break;
            }
        }
        private void PressCard(int boardPosition) {
            board[boardPosition].PressCard();
            UpdateSet(boardPosition);
            if (selectedBoardPositions.Count == 3) {
                allowInteraction = false;
                bool foundSet = CheckSet(selectedBoardPositions[0], selectedBoardPositions[1], selectedBoardPositions[2]);
                UpdateScoreboard(foundSet);
            }
        }
    }

    class BoardPosition {
        private readonly Image connectedImage;
        public Card heldCard;
        private bool isSelected = false;

        public BoardPosition(Image connectedImage) {
            this.connectedImage = connectedImage;
        }

        public void PressCard() {
            if (!isSelected)
                connectedImage.Source = new BitmapImage(new Uri(heldCard.selectedSource, UriKind.Relative));
            else
                connectedImage.Source = new BitmapImage(new Uri(heldCard.unselectedSource, UriKind.Relative));
            isSelected = !isSelected;
        }

        public void HoldCard(Card card) {
            heldCard = card;
            if (heldCard != null)
                connectedImage.Source = new BitmapImage(new Uri(heldCard.unselectedSource, UriKind.Relative));
            else
                connectedImage.Source = null;
        }

        public void TakeCard() {
            if (isSelected)
                isSelected = false;
            heldCard = null;
            connectedImage.Source = null;
        }
    }
    class Card {
        public readonly string unselectedSource;
        public readonly string selectedSource;
        public readonly string id;

        public Card(string unselectedSource, string selectedSource, string id) {
            this.unselectedSource = unselectedSource;
            this.selectedSource = selectedSource;
            this.id = id;
        }
    }
}
