using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    internal class MeanTemperature {
        private int[] circularArray;
        private int nextIndex;
        private bool filled;
        private int? lastValue = null;

        public MeanTemperature(int size) {
            circularArray = new int[size];
        }

        public void Write(int value) {
            circularArray[nextIndex++] = value;
            lastValue = value;
            if (nextIndex >= circularArray.Length) {
                filled = true;
                nextIndex = 0;
            }
        }

        public int GetLastValue(int value) {
            return lastValue.GetValueOrDefault(value);
        }

        public double GetMeanTemperature() {
            int sum = 0;
            int length;
            double result = 0D;
            if (filled) {
                length = circularArray.Length;
                for (int i = 0; i < circularArray.Length; i++) {
                    sum += circularArray[i];
                }
            } else {
                length = nextIndex;
                for (int i = 0; i < nextIndex; i++) {
                    sum += circularArray[i];
                }
            }
            if (length > 0) {
                result = (sum / length) / 10D;
            }
            return result;
        }

        public void Reset() {
            nextIndex = 0;
            filled = false;
            lastValue = null;
        }
    }
}
