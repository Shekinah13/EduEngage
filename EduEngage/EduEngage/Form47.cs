using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EduEngage
{
    public partial class Form47 : Form
    {
        Clues clue_window = new Clues();
        List<id_cells> idc = new List<id_cells>();
        public String puzzle_file = Application.StartupPath + "\\Puzzles\\puzzle_1.pzl";
        private List<string> correctAnswers;

        public Form47()
        {
            buildWordList();
            InitializeComponent();
            correctAnswers = idc.Select(i => i.word.ToUpper()).ToList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void buildWordList()
        {
            String line = "";
            using (StreamReader s = new StreamReader(puzzle_file))
            {
                line = s.ReadLine();
                while ((line = s.ReadLine()) != null)
                {
                    String[] l = line.Split('|');
                    if (l.Length >= 6)
                    {
                        if (int.TryParse(l[0], out int x) && int.TryParse(l[1], out int y))
                        {
                            idc.Add(new id_cells(x, y, l[2], l[3], l[4], l[5]));
                            clue_window.clue_table.Rows.Add(new String[] { l[3], l[2], l[5] });
                        }
                        else
                        {
                            // Handle the case where parsing fails, log an error, or throw an exception.
                            // For now, I'm just printing a message to the console.
                            Console.WriteLine("Failed to parse integers from line: " + line);
                        }
                    }
                    else
                    {
                        // Handle the case where the line doesn't have enough elements.
                        // For now, I'm just printing a message to the console.
                        Console.WriteLine("Invalid line format: " + line);
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help About");
        }

        private void Form47_Load(object sender, EventArgs e)
        {
            InitializeBoard();
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            clue_window.StartPosition = FormStartPosition.Manual;

            clue_window.Show();
            clue_window.clue_table.AutoResizeColumns();
     
        }

        private void InitializeBoard()
        {
            board.BackgroundColor = Color.Black;
            board.DefaultCellStyle.BackColor = Color.Black;

            for (int i = 0; i < 21; i++)
                board.Rows.Add();

            foreach (DataGridViewColumn c in board.Columns)
                c.Width = board.Width / board.Columns.Count;

            foreach (DataGridViewRow r in board.Rows)
                r.Height = board.Height / board.Rows.Count;

            for (int row = 0; row < board.Rows.Count; row++)
            {
                for (int col = 0; col < board.Columns.Count; col++)
                    board[col, row].ReadOnly = true;
            }

            foreach (id_cells i in idc)
            {
                int start_col = i.X;
                int start_row = i.Y;
                char[] word = i.word.ToCharArray();

                for (int j = 0; j < word.Length; j++)
                {
                    if (i.direction.ToUpper() == "ACROSS")
                        formatCell(start_row, start_col + j, word[j].ToString());
                    if (i.direction.ToUpper() == "DOWN")
                        formatCell(start_row + j, start_col, word[j].ToString());
                }
            }
        }

        private void formatCell(int row, int col, String letter)
        {
            DataGridViewCell c = board[col, row];
            c.Style.BackColor = Color.White;
            c.ReadOnly = false;
            c.Style.SelectionBackColor = Color.Cyan;
            c.Tag = letter;
        }

        private void Form47_LocationChanged(object sender, EventArgs e)
        {
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
        }

        private void board_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
            }
            catch { }

            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().Length > 1)
                    board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(0, 1);
            }
            catch { }

            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper().Equals(board[e.ColumnIndex, e.RowIndex].Tag.ToString().ToUpper()))
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGreen;
                else
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
            }
            catch { }
        }

        private void openPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Puzzle Files|*.pzl";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                puzzle_file = ofd.FileName;
                board.Rows.Clear();
                clue_window.clue_table.Rows.Clear();
                idc.Clear();

                buildWordList();
                InitializeBoard();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int correctCount = 0;

            foreach (id_cells i in idc)
            {
                int start_col = i.X;
                int start_row = i.Y;
                char[] word = i.word.ToCharArray();
                bool isCorrect = true;

                for (int j = 0; j < word.Length; j++)
                {
                    string cellValue = "";
                    if (i.direction.ToUpper() == "ACROSS")
                        cellValue = board[start_col + j, start_row].Value?.ToString();
                    else if (i.direction.ToUpper() == "DOWN")
                        cellValue = board[start_col, start_row + j].Value?.ToString();

                    if (string.IsNullOrEmpty(cellValue) || !cellValue.ToUpper().Equals(word[j].ToString().ToUpper()))
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (isCorrect)
                {
                    correctCount++;
                }
            }

            // Display the score in Form55
            Score form55 = new Score(correctCount, idc.Count);
            form55.Show();
            this.Hide();
            clue_window.Hide();
        }

        private void board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            String number = "";

            if (idc.Any(c => (number = c.number) != "" && c.X == e.ColumnIndex && c.Y == e.RowIndex))
            {
                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                e.Graphics.FillRectangle(Brushes.White, r);
                Font f = new Font(e.CellStyle.Font.FontFamily, 7);
                e.Graphics.DrawString(number, f, Brushes.Black, r);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }
    }

    public class id_cells
    {
        public int X;
        public int Y;
        public String direction;
        public String number;
        public String word;
        public String clue;

        public id_cells(int x, int y, String d, String n, String w, String c)
        {
            this.X = x;
            this.Y = y;
            this.direction = d;
            this.number = n;
            this.word = w;
            this.clue = c;
        }
    }
}