using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SpotDifferenceGame
{
    public static class GlobalVaribles
    {
        public static int width = 1920;
        public static int hieght = 1100;
        public static String BackgroundImagePath = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\images\mainPhoto.png";
        public static String BackgroundImagePath2 = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\images\mainPhoto.jpg";
        public static String FirstPhotoDifference = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\images\firstPhoto.png";
        public static PictureBox firstPhoto;
        public static PictureBox secondPhoto;  
        public static String SecondPhotoDifference = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\images\SecondPhoto.png";
        public static String CorrectSoundPath = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\sounds\CorrectAnswersound.wav";
        public static String WrongSoundPath = @"C:\Users\yamen\Desktop\MultiMediaProjects\SpotDifferenceGame\SpotDifferenceGame\sounds\BuzzerWrongAnswer.wav";
        public static bool IsTryings = false;
        public static bool IsTimer = false;
        public static bool IsEasy = false;
        public static bool IsMedium = false;
        public static bool IsHard = false;
        public static bool IsFirstPhoto = false;
        public static bool IsSecondPhoto = false;
        public static int totalSeconds = 0;
        public static int totalTryings = 0;
        public static int LabelXSize = 700;
        public static int LabelYSize = 60;
        public static SoundPlayer correctSound;
        public static SoundPlayer wrongSound;
        public static int differencesRemaining = 3;
    }
}
