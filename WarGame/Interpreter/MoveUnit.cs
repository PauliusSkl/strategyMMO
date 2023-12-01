using Shared.Models.Interpreter;


namespace WarGame.Forms.Interpreter
{
    public class MoveUnit : InterpreterExpression
    {
        public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form)
        {
            if (context.Parameter1 == "green")
            {
                switch (context.Parameter2)
                {
                    case "warrior":
                        PictureBox pictureBox2 = (PictureBox)form.Controls.Find("pictureBox2", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox2, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox2, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox2, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox2, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "archer":
                        PictureBox pictureBox6 = (PictureBox)form.Controls.Find("pictureBox6", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox6, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox6, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox6, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox6, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "mage":
                        PictureBox pictureBox10 = (PictureBox)form.Controls.Find("pictureBox10", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox10, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox10, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox10, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox10, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "tank":
                        PictureBox pictureBox14 = (PictureBox)form.Controls.Find("pictureBox14", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox14, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox14, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox14, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox14, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;

                }
            }

            if (context.Parameter1 == "blue")
            {
                switch (context.Parameter2)
                {
                    case "warrior":
                        PictureBox pictureBox3 = (PictureBox)form.Controls.Find("pictureBox3", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox3, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox3, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox3, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox3, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "archer":
                        PictureBox pictureBox7 = (PictureBox)form.Controls.Find("pictureBox7", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox7, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox7, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox7, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox7, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "mage":
                        PictureBox pictureBox11 = (PictureBox)form.Controls.Find("pictureBox11", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox11, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox11, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox11, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox11, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "tank":
                        PictureBox pictureBox15 = (PictureBox)form.Controls.Find("pictureBox15", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox15, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox15, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox15, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox15, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (context.Parameter1 == "yellow")
            {
                switch (context.Parameter2)
                {
                    case "warrior":
                        PictureBox pictureBox4 = (PictureBox)form.Controls.Find("pictureBox4", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox4, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox4, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox4, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox4, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "archer":
                        PictureBox pictureBox8 = (PictureBox)form.Controls.Find("pictureBox8", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox8, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox8, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox8, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox8, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "mage":
                        PictureBox pictureBox12 = (PictureBox)form.Controls.Find("pictureBox12", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox12, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox12, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox12, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox12, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "tank":
                        PictureBox pictureBox16 = (PictureBox)form.Controls.Find("pictureBox16", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox16, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox16, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox16, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox16, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (context.Parameter1 == "pink")
            {
                switch (context.Parameter2)
                {
                    case "warrior":
                        PictureBox pictureBox5 = (PictureBox)form.Controls.Find("pictureBox5", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox5, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox5, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox5, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox5, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "archer":
                        PictureBox pictureBox9 = (PictureBox)form.Controls.Find("pictureBox9", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox9, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox9, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox9, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox9, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "mage":
                        PictureBox pictureBox13 = (PictureBox)form.Controls.Find("pictureBox13", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox13, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox13, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox13, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox13, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "tank":
                        PictureBox pictureBox17 = (PictureBox)form.Controls.Find("pictureBox17", true).FirstOrDefault();
                        switch (context.Parameter3)
                        {
                            case "up":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox17, new EventArgs());
                                    form.upButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "down":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox17, new EventArgs());
                                    form.downButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "left":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox17, new EventArgs());
                                    form.leftButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            case "right":
                                syncContext.Post(_ =>
                                {
                                    form.clickablePictureBox(pictureBox17, new EventArgs());
                                    form.rightButton_Click(_, new EventArgs());
                                }, null);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
