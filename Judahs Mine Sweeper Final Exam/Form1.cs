using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace Judahs_Mine_Sweeper_Final_Exam
{
    public partial class Form1 : Form
    {
        //create a variable to use later to determine if a win and keep track of the score
        int Score = 0;
        //Create the tiles for the game board
        PictureBox[] tiles = new PictureBox[100];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Gives the opening introduction of the game and tells the rules and how to win.
            MessageBox.Show("Hello Welcome to Judah's Game of MineSweeper!\nGet Ready For Mine Sweeper Hard Mode!\nIn this version, the Computer is essentially the Mines.\n" +
                "We'll call him Jeff.\nJeff is both Rooting for your down fall, and wants you to succeed!\n" +
                "Jeff will give you small messages in the bottom left while you play!\n" +
                "The Message he says is also Tied to the value of each tile.\nSee if you can get a score of 30!\nGood Luck I hope you win!", "MineSweeper", MessageBoxButtons.OK);
            //calls the method load tiles to reset the board and start the game.
            load_Tiles();


        }

        //Create a method the creates the outline borders for each each square and the Picture box
        private void load_Tiles()
        {
            //Picture box tiles is set to an empty picture box with 100 spaces 
            JeffBox.Text = "";
            int x = 0;
            int y = 0;
            int count = 0;
            //get a way to randomize the tiles on the board
            Random random = new Random();
            //Create two string lists for extra messages of a good or bad tile that the computer JeffBot will say.
            List<string> Yaylist = new List<string>();
            List<string> Nolist = new List<string>();
            Nolist.Add("OHHH Try again...");
            Nolist.Add("There's a mine right there...");
            Nolist.Add("SPLOOOoosh...");
            Nolist.Add("Death is what awaits us now...");
            Nolist.Add("The Thousand Yard Stare commences...");


            Yaylist.Add("Alright :)");
            Yaylist.Add("YEEEAAAAAAHHHHHH");
            Yaylist.Add("Oh yeah It's all coming together");
            Yaylist.Add("Now that's what i'm talking about");

            Yaylist.Add("The Bells of the Gion Monastery in India\necho with the warning that all things are impermanent.\n\n" +
                "The blossoms of the sala trees teach us through their hues\n" +
                "that what flourishes must fade.\n\n" +
                "However!\n\nWE ARE THE EXCEPTION!");


            //the for loop attaches the Bomb or dollar to all the tiles on the board in a randomized order.
            for (int i = 0; i < 100; i++)
            {
                Random RandSentence = new Random();
                int messagenum = RandSentence.Next(0, 5);
                //int messagenum2 = RandSentence.Next(0, 5);

                int num = random.Next(0, 2);
                tiles[i] = new PictureBox();
                tiles[i].Height = 40;
                tiles[i].Width = 40;
                tiles[i].Left = x;
                tiles[i].Top = y;
                tiles[i].BorderStyle = BorderStyle.FixedSingle;
                tiles[i].Image = imageList1.Images[2];
                //if num == 0 then it is a bomb
                if (num == 0)
                {
                    //Randomly selects one of the lose messages from the list Nolist
                    tiles[i].Tag = Nolist[messagenum];
                    

                }
                //if num != 0 it is a Dollar sign
                else
                {
                    //Randomly selects one of the correct guess messages from the Yaylist
                    tiles[i].Tag = Yaylist[messagenum];
                    
                }
                //this sets the pictures used to the tiles on the board and makes sure it is a 10 by 10
                tiles[i].SizeMode = PictureBoxSizeMode.StretchImage;
                //it says theres a Nullability of reference types here but i'm not sure what that means but it seems to not affect anything so I left it alone
                tiles[i].Click += new EventHandler(ClickTile);
                panel1.Controls.Add(tiles[i]);
                x = x + 40;
                count++;
                if (count == 10)
                {
                    x=0;
                    y = y + 40;
                    count = 0;
                }



            }
        }
        //This method is to check if a tile has been clicked
        private void ClickTile(object sender, EventArgs e)
        {
            //create variable to be used later to continue playing, play again, or quit playing
            DialogResult Answer;
            //checks to see the clicked box and sets it to the selected box value
            PictureBox tile2 = (PictureBox)sender;
            JeffBox.Text = "";
            //MessageBox.Show(tiles.Tag.ToString());
            if (tile2.Tag.ToString()!="Clicked")
            {

                //I'm sure there was easier way to this next part but i had already started and wasnt sure how to do it without adding a lot of extra work for myself so there
                //are severl if statements to check for which exact loss screen you get. 

                //Checks tile2 if its set to a message from the Nolist list and if its equal to one it brings forth a game over sreen
                if (tile2.Tag.ToString() == "OHHH Try again...")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[0];
                    //Shows a game over screen that asks the user if they want play again and display their score and has a personalized loss message depending on the loss you get
                    Answer = MessageBox.Show("GAME OVER!!!\n"+ "Your Score: "+ Score.ToString() + "\nWould you like to Play again with Jeff?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        //resets the score to 0
                        Score = 0;
                        //resets the label score to show Zero when starting
                        lblScore.Text = "0";
                        //this clears the board and resets the tiles back to the original image of the gray tile
                        foreach (PictureBox tile in tiles)
                        {
                            panel1.Controls.Remove(tile);
                        }
                        //calls the method which randomizes the board and resets everything.
                        load_Tiles();
                    }
                    //if the user answered No then this ends the application.
                    else
                    {
                        Application.Exit();
                    }
                }
                else if (tile2.Tag.ToString() == "There's a mine right there...")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[0];
                    Answer = MessageBox.Show("HAHAHAHAHAH YOU LOSE\n"+ "Your Score: "+ Score.ToString() + "\nWould you like to Play again with Jeff?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        Score = 0;
                        lblScore.Text = "0";
                        foreach (PictureBox tile in tiles)
                        {
                            panel1.Controls.Remove(tile);
                        }
                        load_Tiles();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else if (tile2.Tag.ToString() == "SPLOOOoosh...")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[0];
                    Answer = MessageBox.Show("Its ok buddy you go when you feel like it\n"+ "Your Score: "+ Score.ToString() + "\nWould you like to Play again with Jeff?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        Score = 0;
                        lblScore.Text = "0";
                        foreach (PictureBox tile in tiles)
                        {
                            panel1.Controls.Remove(tile);
                        }
                        load_Tiles();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else if (tile2.Tag.ToString() == "Death is what awaits us now...")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[0];
                    Answer = MessageBox.Show("OHH TRY AGAIN LOSER\n"+ "Your Score: "+ Score.ToString() + "\nWould you like to Play again with Jeff?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        Score = 0;
                        lblScore.Text = "0";
                        foreach (PictureBox tile in tiles)
                        {
                            panel1.Controls.Remove(tile);
                        }
                        load_Tiles();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else if (tile2.Tag.ToString() == "The Thousand Yard Stare commences...")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[0];
                    Answer = MessageBox.Show("The Thousand Yard Stare Commences...\n"+ "Your Score: "+ Score.ToString() + "\nWould you like to Play again with Jeff?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        Score = 0;
                        lblScore.Text = "0";
                        foreach (PictureBox tile in tiles)
                        {
                            panel1.Controls.Remove(tile);
                        }
                        load_Tiles();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }

                //Similar the end screens this checks which message is selected and gives a different score based on which messaged gets picked
                else if (tile2.Tag.ToString() == "Alright :)")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[1];
                    //this now sets the current tile to have a clicked property essentially, to ensure that no cheating such as clicking the same box over and over again can happen.
                    tile2.Tag = "Clicked";
                    //adds 3 the score varibale
                    Score += 3;
                    //updates the score label
                    lblScore.Text = Score.ToString();
                }
                else if (tile2.Tag.ToString() == "YEEEAAAAAAHHHHHH")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[1];
                    tile2.Tag = "Clicked";
                    //adds 5 to the score variable and updates the score label to add 5 
                    Score += 5;
                    lblScore.Text = Score.ToString();
                }
                else if (tile2.Tag.ToString() == "Oh yeah It's all coming together")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[1];
                    tile2.Tag = "Clicked";
                    //adds 7 the score variable and updates the score label to add 7
                    Score += 7;
                    lblScore.Text = Score.ToString();
                }
                else if (tile2.Tag.ToString() == "Now that's what i'm talking about")
                {
                    JeffBox.Text = tile2.Tag.ToString();
                    tile2.Image = imageList1.Images[1];
                    tile2.Tag = "Clicked";
                    //adds 5 to the score variable and updates the score label to add 5 
                    Score += 5;
                    lblScore.Text = Score.ToString();
                }
                else if (tile2.Tag.ToString() == "The Bells of the Gion Monastery in India\necho with the warning that all things are impermanent.\n\n" +
                    "The blossoms of the sala trees teach us through their hues\n" +
                    "that what flourishes must fade.\n\n" +
                    "However!\n\nWE ARE THE EXCEPTION!")
                {
                    JeffBox.Text = "The Bells of the Gion Monastery in India\n echo with the warning that all things are impermanent. \n The blossoms of the sala trees teach us through their hues\n that what flourishes, must fade.                   \nHowever!                                                 \n WE ARE THE EXCEPTION!";
                    tile2.Image = imageList1.Images[1];
                    tile2.Tag = "Clicked";
                    //this one being the longest message and my personal favorite adds 10 to the score and updates the label to add 10
                    Score += 10;
                    lblScore.Text = Score.ToString();
                }
                //This if statement checks to see if the player has achieved a score of 30. it is also set to appear if it is less than 40.
                //this is to ensure the player cant miss their win screen and so the win screen doesn't appear every successful click going forward.
                // however if one were to have a score of 30 and they get the message worth 3, 3 times in a row then this message will pop up a total of 4 times while playing.
                if(Score >=30 && Score<=40)
                {
                    //sets the JeffBox to my favorote message at win screen
                    JeffBox.Text = "The Bells of the Gion Monastery in India\n echo with the warning that all things are impermanent. \n The blossoms of the sala trees teach us through their hues\n that what flourishes, must fade.                   \nHowever!                                                 \n WE ARE THE EXCEPTION!";
                    //asks the user if they would like to keep playing and informs them of the possibility of a hidden win screen at 100 which is incredidbly hard to achieve. 
                    Answer = MessageBox.Show("WOW YOU'RE INCREDIBLE!!!\nYou managed to get a score of 30!!!\nThink you can get to 100?\nWould you like to keep playing?","WINNER WINNER CHICKEN DINNER!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(Answer == DialogResult.No)
                    {
                        //if the user answeres yes they simply keep playing. if they answer no the game ends and the application closes
                        Application.Exit();
                    }
                }
                //Shows a special funny message if the player is somehow able to get the incredibly lucky score of 100+
                //this screen will pop up for every continued successful selection after 100
                if (Score >=100)
                {
                    JeffBox.Text = "Are you stand proud Cause You're Nah Id win? Or are you Nah id win cause you're With this treausre I summon Always Bet on Jogoat. Beacause I alone Am the Honored One.";
                    MessageBox.Show("Stand Proud. You are Strong.", "Stand Strong You are Proud.", MessageBoxButtons.OK);
                }
            }
            //if the user tries to double click an uncovered dollar tile to gain more points it displays a screen that says no cheating
            else
            {
                MessageBox.Show("Uh uh UH No CHEATING!!!\nPlease pick an Unselected Tile.", "Cheater cheater pumpkin eater.", MessageBoxButtons.OK);

            }

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void JeffBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}