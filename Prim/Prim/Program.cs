using System;
using System.Collections.Generic;
using System.Linq;

namespace Prim
{
    class Program
    {
        List<Tree> node = new List<Tree>();

        static void Main(string[] args) {
            Program program = new Program();

            program.InputArraydata();
        }

        private void InputArraydata() {
            int totalWeight = 0;

            AddListStruct(1, 2, 1);
            AddListStruct(2, 3, 2);
            AddListStruct(1, 3, 3);

            PrtInputValue();

            AssendingSort();

            totalWeight = MoveNode();

            PrtTotalWeight(totalWeight);
        }

        private void PrtInputValue() {
            foreach (var item in node) {
                Console.WriteLine($"{item.parent}    {item.child}    {item.weight}");
            }
        }

        private void AssendingSort() {
            node = node.OrderBy(x => x.child).ToList();
            node = node.OrderBy(x => x.weight).ToList();
            node = node.OrderBy(x => x.parent).ToList();
        }

        private void AddListStruct(int parent, int child, int weight) => node.Add(new Tree(parent, child, weight));

        private int MoveNode() {
            int accumulate = 0, currentNode = node[0].parent;

            Console.Write($"{currentNode} ");

            while (true) {
                try {
                    if(node[0].parent == node[node.Count - 1].parent) {
                        throw new PrimOutOfRangeException();
                    }

                    accumulate += node[0].weight;
                    currentNode = node[0].child;
                    DeleteNode(node[0].parent);

                }
                catch (ArgumentOutOfRangeException) {
                    break;
                }
                catch (PrimOutOfRangeException) {
                    accumulate += node[0].weight;
                    Console.Write($"=> {node[0].parent} ");
                    Console.Write($"=> {node[0].child}");
                    break;
                }
            }
            return accumulate;
        }

        private void DeleteNode(int parent) {
            for (int idx = 0; idx < node.Count; idx++) {
                if (parent == node[idx].parent) {
                    node.RemoveAt(idx);
                    idx--;
                }
            }
        }

        private void PrtTotalWeight(int value) {
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine($"   Weight:: {value}");
            Console.WriteLine("====================");
        }
    }
}