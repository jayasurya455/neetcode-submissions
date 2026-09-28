public class LRUCache {
    Dictionary<int, LinkedListNode<(int key, int val)>> map = new Dictionary<int, LinkedListNode<(int key, int val)>>();
    LinkedList<(int key, int val)> list = new();
    int _capacity = 0; 

    public LRUCache(int capacity) {
        _capacity = capacity;
        map = new Dictionary<int, LinkedListNode<(int key, int val)>>();
        list = new LinkedList<(int key, int val)>();
    }
    
    public int Get(int key) {
        if(!map.TryGetValue(key, out var node))
        {
            return -1;
        }
        list.Remove(node);
        list.AddLast(node);
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key))
        {
            list.Remove(map[key]);
        }
        else if(map.Count == _capacity)
        {
            var node = list.First;
            map.Remove(node.Value.key);
            list.RemoveFirst();
        }
        var newNode = list.AddLast((key, value));
        map[key] = newNode;
    }
}
