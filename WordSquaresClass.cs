public class Solution {
    // TC => O(n^k)
    // SC => O(nk)
    public class TrieNode{
        public TrieNode[] Children;
        public List<string> StartsWith;

        public TrieNode(){
            Children = new TrieNode[26];
            StartsWith = new List<string>();
        }
    }
    TrieNode root;
    IList<IList<string>> result;
    
    public void Insert(string word){
        TrieNode current = root;
        for(int i = 0; i< word.Length; i++){
            var c = word[i];
            if(current.Children[c - 'a'] == null){
                current.Children[c - 'a'] = new TrieNode();
            }
            current = current.Children[c - 'a'];
            current.StartsWith.Add(word);
        }
    }

    public List<string> StartsWith(string prefix){
        TrieNode current = root;
        for(int i = 0; i < prefix.Length; i++){
            var c = prefix[i];
            if(current.Children[c - 'a'] == null){
                return new List<string>();
            }
            current = current.Children[c - 'a'];
        }
        return current.StartsWith;
    }
    public IList<IList<string>> WordSquares(string[] words) {
        if(words == null || words.Length == 0){
            return new List<IList<string>>();
        }
        root = new TrieNode();
        result = new List<IList<string>>();

        foreach(var w in words){
            Insert(w);
        }

        var list = new List<string>();
        foreach(var w in words){
            //action
            list.Add(w);

            //recurse
            Backtrack(list);

            //backtrack
            list.RemoveAt(list.Count - 1);
        }

        return result;
    }

    public void Backtrack(List<string> wordList){
        //base
        if(wordList.Count == wordList[0].Length){
            result.Add(new List<string>(wordList));
            return;
        }

        //logic
        StringBuilder sb = new StringBuilder();
        var index = wordList.Count;
        foreach(var word in wordList){
            sb.Append(word[index]);
        }
        List<string> words = StartsWith(sb.ToString());

        foreach(var word in words){
            //Action
            wordList.Add(word);

            //recurse
            Backtrack(wordList);

            //backtrack
            wordList.RemoveAt(wordList.Count - 1);
        } 
    }
}