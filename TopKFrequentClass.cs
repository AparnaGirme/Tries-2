public class Solution {
    // TC => O(n)
    // SC => O(n)
    public int[] TopKFrequent(int[] nums, int k){
        if(nums == null || nums.Length == 0){
            return new int[1];
        }

        Dictionary<int, int> lookup = new Dictionary<int, int>();
        int max = 0;
        foreach(var nm in nums){
            lookup.TryAdd(nm, 0);
            lookup[nm]++;
            max = Math.Max(max, lookup[nm]);
        }

        List<List<int>> buckets = new List<List<int>>(max + 1);
        
        for(int i = 0; i< max+1;i++){
            buckets.Add(new List<int>());
        }
        
        foreach(var kv in lookup){
            // if(buckets[kv.Value] == null){
            //     buckets[kv.Value] = new List<int>();
            // }
            buckets[kv.Value].Add(kv.Key);
        }
        
        int[] result = new int[k];
        for(int i = max; i >= 0; i--){
            if(buckets[i].Count == 0){
                continue;
            }
            foreach(var b in buckets[i]){
                result[--k] = b;
                if(k <= 0){
                    break;
                }
            }
            if(k <= 0){
                break;
            }

        }

        return result;
    }
    // TC => O(n log k)
    // SC => O(n)
    public int[] TopKFrequent1(int[] nums, int k) {
        if(nums == null || nums.Length == 0){
            return new int[1];
        }

        Dictionary<int, int> lookup = new Dictionary<int, int>();
        foreach(var nm in nums){
            lookup.TryAdd(nm, 0);
            lookup[nm]++;
        }

        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

        foreach(var kv in lookup){
            queue.Enqueue(kv.Key, kv.Value);
            if(queue.Count > k){
                queue.Dequeue();
            }
        }

        int[] result = new int[k];
        while(queue.Count > 0){
            result[--k] = queue.Dequeue();
        }

        return result;
    }
}