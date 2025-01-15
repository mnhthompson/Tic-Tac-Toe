namespace TicTacToe
{
    public partial class Form1 : Form
    {


        //special varible that makes the player X and the Cpu O
        public enum Player
        {
            X,O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

// opens the window the game is in
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        //this is the computers turn
        private void cpumove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;  //turns the button off
                currentPlayer = Player.O;  
                buttons[index].Text = currentPlayer.ToString(); //changes the Shape
                buttons[index].BackColor = Color.DarkSalmon;  //changes the color
                buttons.RemoveAt(index);
                CheckGame();
                CPUTIMER.Stop(); //makes it not the computers turn
            }
        }

        //this is the Players turn
        private void PlayerClickButton(object sender, EventArgs e)

        {
            var button = (Button)sender;

            currentPlayer =Player.X;   

            button.Text = currentPlayer.ToString(); //changes the Shape 
            button.Enabled = false;    //turns the button off
            button.BackColor = Color.Cyan;   //changes the color
            buttons.Remove(button); 
            CheckGame();
            CPUTIMER.Start();  //makes it the computers turn
        }

        // this is the button click tht activates the reset game function

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();

        }
        // this sees if the game was won
        private void CheckGame()
        {
           
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTIMER.Stop();  //makes it not the computers turn
                MessageBox.Show("Player Wins"); 
                playerWinCount++; 
                label1.Text = "Player Wins : " + playerWinCount; // updates the win count
                RestartGame(); 
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
              
                CPUTIMER.Stop();  //makes it not the computers turn
                MessageBox.Show("Computer Wins");
                CPUWinCount++; 
                label2.Text = "COM Wins : " + CPUWinCount; // updates the win count
                RestartGame(); 

            }
        }
         // the reset game function
        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = default;
            } 
        }
    }
}
