using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HRBetweenTwoSets {
    class Program {
        static void Main(string[] args) {

            List<int> a = new List<int> { 2 };
            List<int> b = new List<int> { 20, 30, 12 };

            int bMin = b.Min();

            List<int> muls = new List<int>();
            List<int> factors = new List<int>();

            // get all of the multiples of list a that evenly divide into lowest number of b
            foreach (var num in a) {
                for (var i = 1; i <= bMin; i++) {
                    if (!muls.Contains(i * num) && (i * num) <= bMin && bMin % (i * num) == 0) {
                        muls.Add(i * num);
                        factors.Add(i * num);
                    }
                }
            }

            // remove any multiples that aren't multiples for every value in a
            foreach(var mul in muls) {
                foreach(var num in a) {
                    if(mul % num != 0) {
                        factors.Remove(mul);
                    }
                }
            }

            // remove any multiples that don't divide evenly in to every number of b
            foreach(var i in b) {
                foreach(var m in muls) {
                    if(i % m != 0) {    
                        factors.Remove(m);
                    }
                }
            }
            return factors.Count();
        }
    }
}
