using LoLRunes.CustumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Domain.Models
{
    [Serializable]
    public class RunePagePositions
    {
        #region Main Path
        public Point2D mainPath_01;
        public Point2D mainPath_02;
        public Point2D mainPath_03;
        public Point2D mainPath_04;
        public Point2D mainPath_05;
        #endregion

        #region Side Path
        public Point2D sidePath_01;
        public Point2D sidePath_02;
        public Point2D sidePath_03;
        public Point2D sidePath_04;
        #endregion

        #region Key Stones
        public Point2D keyStone_01_01;
        public Point2D keyStone_01_02;
        public Point2D keyStone_01_03;
        public Point2D keyStone_01_04;

        public Point2D keyStone_02_01;
        public Point2D keyStone_02_02;
        public Point2D keyStone_02_03;
        #endregion

        #region Main Path Rune Slots
        public Point2D mainRuneSlot_01_01;
        public Point2D mainRuneSlot_01_02;
        public Point2D mainRuneSlot_01_03;

        public Point2D mainRuneSlot_02_01;
        public Point2D mainRuneSlot_02_02;
        public Point2D mainRuneSlot_02_03;

        public Point2D mainRuneSlot_03_01;
        public Point2D mainRuneSlot_03_02;
        public Point2D mainRuneSlot_03_03;

        public Point2D mainRuneSlot_04_01;
        public Point2D mainRuneSlot_04_02;
        public Point2D mainRuneSlot_04_03;
        public Point2D mainRuneSlot_04_04;
        #endregion

        #region Side Path Rune Slots
        public Point2D sideRuneSlot_01_01;
        public Point2D sideRuneSlot_01_02;
        public Point2D sideRuneSlot_01_03;
                       
        public Point2D sideRuneSlot_02_01;
        public Point2D sideRuneSlot_02_02;
        public Point2D sideRuneSlot_02_03;
                       
        public Point2D sideRuneSlot_03_01;
        public Point2D sideRuneSlot_03_02;
        public Point2D sideRuneSlot_03_03;
                       
        public Point2D sideRuneSlot_04_01;
        public Point2D sideRuneSlot_04_02;
        public Point2D sideRuneSlot_04_03;
        public Point2D sideRuneSlot_04_04;
        #endregion

        #region Shard Slots
        public Point2D shardSlot_01_01;
        public Point2D shardSlot_01_02;
        public Point2D shardSlot_01_03;
                            
        public Point2D shardSlot_02_01;
        public Point2D shardSlot_02_02;
        public Point2D shardSlot_02_03;
                            
        public Point2D shardSlot_03_01;
        public Point2D shardSlot_03_02;
        public Point2D shardSlot_03_03;
        #endregion
    }
}
