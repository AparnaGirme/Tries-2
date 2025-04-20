public class Solution {
    // TC => O(nk)
    // SC => O(1)
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        if(queries == null || queries.Length == 0 || string.IsNullOrEmpty(pattern)){
            return new List<bool>();
        }
        IList<bool> result = new List<bool>();

        foreach(var q in queries){
            int i = 0;
            bool flag = true;
            for(int j = 0; j < q.Length; j++){
                if(i < pattern.Length && q[j] == pattern[i]){
                    i++;
                    continue;
                }
                if(char.IsUpper(q[j])) //&& (i >= pattern.Length || q[j] != pattern[i])
                {
                    flag = false;
                    break;
                }

            }
            if(flag && i == pattern.Length){
                result.Add(true);
                continue;
            }
            result.Add(false);
        }
        return result;
    }
}