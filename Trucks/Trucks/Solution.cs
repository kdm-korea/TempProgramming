using System;
using System.Collections.Generic;

namespace Trucks
{
    class Solution
    {
        Queue<Truck> truck = new Queue<Truck>();
        int idx = 0, time_stamp = 0, time = 0;
        int total_weight = 0;

        public int solution(int bridge_length, int weight, int[] truck_weights) {
            while (true) {
                if (total_weight <= weight && idx + 1 == truck_weights.Length) {
                    truck.Enqueue(new Truck(truck_weights[idx++], 0));
                    AddTimeStamp();
                    OutofBridge(weight);
                }
                else {
                    AddTimeStamp();
                    OutofBridge(weight);
                }

                time++;

                if (truck.Count == 0) {
                    break;
                }
            }
            return time;
        }

        private void OutofBridge(int weight) {
            if (truck.Peek().time_stamp == weight) {
                truck.Dequeue();
            }
        }

        private void AddTimeStamp() {
            foreach (var t in truck) {
                t.time_stamp += 1;
            }
        }
    }

    class Truck
    {
        public int truck_weight = 0;
        public int time_stamp = 0;

        public Truck(int truck_weight, int time_stamp) {
            this.truck_weight = truck_weight;
            this.time_stamp = time_stamp;
        }
    }
}
