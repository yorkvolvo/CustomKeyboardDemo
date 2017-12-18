using System.Text;
using System;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using CustomKeyboardDemo;
using CustomKeyboardDemo.iOS;

[assembly: ExportRenderer(typeof(MyKeyboardPage), typeof(KeyboardPageRenderer))]
namespace CustomKeyboardDemo.iOS
{
    class KeyboardPageRenderer : PageRenderer
    {
        UIToolbar toolbar;
        UITextField target1;
        UITextField target2;
        UITextField target3;
        UITextField target4;
        UITextField target5;
        UITextField target;
        UIView keyboard;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupUserInterface();

            GenerateKeys();

            //Assign keyboard
            target1.KeyboardAppearance = UIKeyboardAppearance.Default;
            target1.InputView = keyboard;
            target2.KeyboardAppearance = UIKeyboardAppearance.Default;
            target2.InputView = keyboard;
            target3.KeyboardAppearance = UIKeyboardAppearance.Default;
            target3.InputView = keyboard;
            //target4.KeyboardAppearance = UIKeyboardAppearance.Default;
            //target4.InputView = keyboard;
            //target5.KeyboardAppearance = UIKeyboardAppearance.Default;
            //target5.InputView = keyboard;

            target = target1;
        }

        private void GenerateKeys()
        {
            var width = this.View.Frame.Size.Width;
            var height = 280.0f;
            keyboard = new UIView(new CGRect(new nfloat(0.0f), new nfloat(0.0f), width, new nfloat(280.0f)));
            keyboard.BackgroundColor = UIColor.LightGray;
            var backgroundColor = UIColor.White;
            var titleColor = UIColor.Gray;
            var buttonCornerRadius = 5;
            var keyWidth = width / 7.5;
            var keyHeight = height / 5.5;
            var keyGap = width / 35;              //Margin between keys
            var largeKeyGap = (width / 20) * 2;   //Used to seperate letters from numbers

            var firstButtonX = width / 20 * 1.5;
            var secondButtonX = firstButtonX + keyWidth + keyGap;
            var thirdButtonX = secondButtonX + keyWidth + largeKeyGap;
            var fourthButtonX = thirdButtonX + keyWidth + keyGap;
            var fifthButtonX = fourthButtonX + keyWidth + keyGap;

            var firstRowVertMargin = keyGap * 2;
            var secondRowVertMargin = firstRowVertMargin + keyHeight + keyGap;
            var thirdRowVertMargin = secondRowVertMargin + keyHeight + keyGap;
            var fourthRowVertMargin = thirdRowVertMargin + keyHeight + keyGap;

            //Row 1
            var aButton = new UIButton()
            {
                Frame = new CGRect(firstButtonX, firstRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor,
            };
            var bButton = new UIButton()
            {
                Frame = new CGRect(secondButtonX, firstRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var sevenButton = new UIButton()
            {
                Frame = new CGRect(thirdButtonX, firstRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var eightButton = new UIButton()
            {
                Frame = new CGRect(fourthButtonX, firstRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var nineButton = new UIButton()
            {
                Frame = new CGRect(fifthButtonX, firstRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };

            aButton.SetTitle("A", UIControlState.Normal);
            aButton.SetTitleColor(titleColor, UIControlState.Normal);
            aButton.Layer.CornerRadius = buttonCornerRadius;
            aButton.TouchUpInside += AddTLD;
            bButton.SetTitle("B", UIControlState.Normal);
            bButton.SetTitleColor(titleColor, UIControlState.Normal);
            bButton.Layer.CornerRadius = buttonCornerRadius;
            bButton.TouchUpInside += AddTLD;
            sevenButton.SetTitle("7", UIControlState.Normal);
            sevenButton.SetTitleColor(titleColor, UIControlState.Normal);
            sevenButton.Layer.CornerRadius = buttonCornerRadius;
            sevenButton.TouchUpInside += AddTLD;
            eightButton.SetTitle("8", UIControlState.Normal);
            eightButton.SetTitleColor(titleColor, UIControlState.Normal);
            eightButton.Layer.CornerRadius = buttonCornerRadius;
            eightButton.TouchUpInside += AddTLD;
            nineButton.SetTitle("9", UIControlState.Normal);
            nineButton.SetTitleColor(titleColor, UIControlState.Normal);
            nineButton.Layer.CornerRadius = buttonCornerRadius;
            nineButton.TouchUpInside += AddTLD;

            keyboard.AddSubview(aButton);
            keyboard.AddSubview(bButton);
            keyboard.AddSubview(sevenButton);
            keyboard.AddSubview(eightButton);
            keyboard.AddSubview(nineButton);

            //Row 2
            var cButton = new UIButton()
            {
                Frame = new CGRect(firstButtonX, secondRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var dButton = new UIButton()
            {
                Frame = new CGRect(secondButtonX, secondRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var fourButton = new UIButton()
            {
                Frame = new CGRect(thirdButtonX, secondRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var fiveButton = new UIButton()
            {
                Frame = new CGRect(fourthButtonX, secondRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var sixButton = new UIButton()
            {
                Frame = new CGRect(fifthButtonX, secondRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };

            cButton.SetTitle("C", UIControlState.Normal);
            cButton.SetTitleColor(titleColor, UIControlState.Normal);
            cButton.Layer.CornerRadius = buttonCornerRadius;
            cButton.TouchUpInside += AddTLD;
            dButton.SetTitle("D", UIControlState.Normal);
            dButton.SetTitleColor(titleColor, UIControlState.Normal);
            dButton.Layer.CornerRadius = buttonCornerRadius;
            dButton.TouchUpInside += AddTLD;
            fourButton.SetTitle("4", UIControlState.Normal);
            fourButton.SetTitleColor(titleColor, UIControlState.Normal);
            fourButton.Layer.CornerRadius = buttonCornerRadius;
            fourButton.TouchUpInside += AddTLD;
            fiveButton.SetTitle("5", UIControlState.Normal);
            fiveButton.SetTitleColor(titleColor, UIControlState.Normal);
            fiveButton.Layer.CornerRadius = buttonCornerRadius;
            fiveButton.TouchUpInside += AddTLD;
            sixButton.SetTitle("6", UIControlState.Normal);
            sixButton.SetTitleColor(titleColor, UIControlState.Normal);
            sixButton.Layer.CornerRadius = buttonCornerRadius;
            sixButton.TouchUpInside += AddTLD;

            keyboard.AddSubview(cButton);
            keyboard.AddSubview(dButton);
            keyboard.AddSubview(fourButton);
            keyboard.AddSubview(fiveButton);
            keyboard.AddSubview(sixButton);

            //Row 3
            var eButton = new UIButton()
            {
                Frame = new CGRect(firstButtonX, thirdRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var fButton = new UIButton()
            {
                Frame = new CGRect(secondButtonX, thirdRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var oneButton = new UIButton()
            {
                Frame = new CGRect(thirdButtonX, thirdRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var twoButton = new UIButton()
            {
                Frame = new CGRect(fourthButtonX, thirdRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var threeButton = new UIButton()
            {
                Frame = new CGRect(fifthButtonX, thirdRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };

            eButton.SetTitle("E", UIControlState.Normal);
            eButton.SetTitleColor(titleColor, UIControlState.Normal);
            eButton.Layer.CornerRadius = buttonCornerRadius;
            eButton.TouchUpInside += AddTLD;
            fButton.SetTitle("F", UIControlState.Normal);
            fButton.SetTitleColor(titleColor, UIControlState.Normal);
            fButton.Layer.CornerRadius = buttonCornerRadius;
            fButton.TouchUpInside += AddTLD;
            oneButton.SetTitle("1", UIControlState.Normal);
            oneButton.SetTitleColor(titleColor, UIControlState.Normal);
            oneButton.Layer.CornerRadius = buttonCornerRadius;
            oneButton.TouchUpInside += AddTLD;
            twoButton.SetTitle("2", UIControlState.Normal);
            twoButton.SetTitleColor(titleColor, UIControlState.Normal);
            twoButton.Layer.CornerRadius = buttonCornerRadius;
            twoButton.TouchUpInside += AddTLD;
            threeButton.SetTitle("3", UIControlState.Normal);
            threeButton.SetTitleColor(titleColor, UIControlState.Normal);
            threeButton.Layer.CornerRadius = buttonCornerRadius;
            threeButton.TouchUpInside += AddTLD;

            keyboard.AddSubview(eButton);
            keyboard.AddSubview(fButton);
            keyboard.AddSubview(oneButton);
            keyboard.AddSubview(twoButton);
            keyboard.AddSubview(threeButton);

            //Row 4
            var zeroButton = new UIButton()
            {
                Frame = new CGRect(fourthButtonX, fourthRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };
            var backButton = new UIButton()
            {
                Frame = new CGRect(fifthButtonX, fourthRowVertMargin, keyWidth, keyHeight),
                BackgroundColor = backgroundColor
            };

            zeroButton.SetTitle("0", UIControlState.Normal);
            zeroButton.SetTitleColor(titleColor, UIControlState.Normal);
            zeroButton.Layer.CornerRadius = buttonCornerRadius;
            zeroButton.TouchUpInside += AddTLD;
            backButton.SetTitle("<", UIControlState.Normal);
            backButton.SetTitleColor(titleColor, UIControlState.Normal);
            backButton.Layer.CornerRadius = buttonCornerRadius;
            backButton.TouchUpInside += AddTLD;

            keyboard.AddSubview(zeroButton);
            keyboard.AddSubview(backButton);

        }
        private void SetupUserInterface()
        {
            var width = View.Bounds.Width;

            var enterRecovText = new UILabel
            {
                Text = "Enter Recovery Key",
                Font = UIFont.FromName("Helvetica", 24),
                Frame = new CGRect(18f, 20f, View.Bounds.Width - 36f, 30f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Gray
            };

            var whereIsKeyText = new UILabel
            {
                Text = "Enter the Recovery Key in the field below.",
                Font = UIFont.FromName("Helvetica", 16),
                Frame = new CGRect(18f, 60f, View.Bounds.Width - 36f, 30f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Gray
            };

            var border = new UIView(new CGRect(new nfloat(18f), new nfloat(100f), width - 36f, 1f));
            border.BackgroundColor = UIColor.Gray;

            var textViewWidth = width / 6;
            var textMargin = 4f;
            var dashWidth = 4f;


            //Target 1 of 5
            target1 = new UITextField()
            {
                Frame = new CGRect(18f, 120f, textViewWidth * 2, 30f),
                TextAlignment = UITextAlignment.Left,
            };
            target1.Font = UIFont.FromName("Helvetica-Bold", 20f);
            target1.EditingDidBegin += (sender, ea) => { target = target1; };

            var underlineBorder1 = new UIView(new CGRect(new nfloat(18f), 120f + 30f, textViewWidth * 2, 1f));
            underlineBorder1.BackgroundColor = UIColor.Gray;

            var dashLabel1 = new UILabel
            {
                Text = "-",
                Font = (UIFont.FromName("Helvetica", 20)),
                Frame = new CGRect(18f + (textViewWidth * 2) + textMargin, 120f, dashWidth, 30f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Gray
            };

            //Target 2 of 5
            target2 = new UITextField()
            {
                Frame = new CGRect(18f + (textViewWidth * 2) + (textMargin * 2) + dashWidth, 120f, textViewWidth, 30f),
                TextAlignment = UITextAlignment.Left,
            };
            target2.Font = UIFont.FromName("Helvetica-Bold", 20f);
            target2.EditingDidBegin += (sender, ea) => { target = target2; };

            var underlineBorder2 = new UIView(new CGRect(18f + (textViewWidth * 2) + (textMargin * 2) + dashWidth, 120f + 30f, textViewWidth, 1f));
            underlineBorder2.BackgroundColor = UIColor.Gray;

            var dashLabel2 = new UILabel
            {
                Text = "-",
                Font = (UIFont.FromName("Helvetica", 20)),
                Frame = new CGRect(18f + (textViewWidth * 3) + (textMargin * 3) + dashWidth, 120f, dashWidth, 30f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Gray
            };

            //Target 3 of 5
            target3 = new UITextField()
            {
                Frame = new CGRect(18f + (textViewWidth * 3) + (textMargin * 4) + (dashWidth * 2), 120f, textViewWidth, 30f),
                TextAlignment = UITextAlignment.Left,
            };
            target3.Font = UIFont.FromName("Helvetica-Bold", 20f);
            target3.EditingDidBegin += (sender, ea) => { target = target3; };

            var underlineBorder3 = new UIView(new CGRect(18f + (textViewWidth * 3) + (textMargin * 4) + (dashWidth * 2), 120f + 30f, textViewWidth, 1f));
            underlineBorder3.BackgroundColor = UIColor.Gray;

            var content = new UIView(new CGRect(new nfloat(0.0f), new nfloat(0.0f), View.Bounds.Width, View.Bounds.Height));

            content.AddSubview(enterRecovText);
            content.AddSubview(whereIsKeyText);
            content.AddSubview(border);
            content.AddSubview(target1);
            content.AddSubview(dashLabel1);
            content.AddSubview(underlineBorder1);
            content.AddSubview(target2);
            content.AddSubview(dashLabel2);
            content.AddSubview(underlineBorder2);
            content.AddSubview(target3);
            content.AddSubview(underlineBorder3);
            View.Add(content);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void AddTLD(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            string prefix;
            string suffix;
            //var index = (int)target.SelectedTextRange.Start.;
            var index = (int)target.GetOffsetFromPosition(target.BeginningOfDocument, target.SelectedTextRange.Start);
            //var selectedLength = (int)target.SelectedRange.Length;
            var selectedLength = (int)target.GetOffsetFromPosition(target.SelectedTextRange.Start, target.SelectedTextRange.End);
            var newCursorLocation = index;

            //Track cursor location 
            if (index == target.Text.Length)
            {
                prefix = target.Text;
                suffix = "";
            }
            else
            {
                prefix = target.Text.Substring(0, index);
                suffix = target.Text.Substring(index, target.Text.Length - index);
            }


            var txt = ((UIButton)sender).CurrentTitle;
            if (txt == "<" && prefix.Length + suffix.Length > 0)
            {
                if (selectedLength == 0)
                {
                    target.Text = prefix.Substring(0, prefix.Length - 1) + suffix;
                    newCursorLocation--;
                }
                else
                {
                    target.Text = prefix.Substring(0, prefix.Length) + suffix.Substring(selectedLength, suffix.Length - selectedLength);
                }
            }
            else if (txt.Length > 0 && txt != "<")
            {
                var addedText = txt;
                if (txt == "Enter")
                {
                    addedText = "\n";
                }

                if (selectedLength == 0)
                {
                    target.Text = String.Format("{0}{1}", prefix, addedText) + suffix;
                }
                else
                {
                    target.Text = prefix + addedText + suffix.Substring(selectedLength, suffix.Length - selectedLength);
                }
                newCursorLocation++;
            }

            //Set cursor position or else it'll move to end
            var positionToSet = target.GetPosition(target.BeginningOfDocument, newCursorLocation);
            target.SelectedTextRange = target.GetTextRange(positionToSet, positionToSet);
        }

    }
}