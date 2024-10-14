class SelectionSort(List<int> arr) {
    private List<int> arr {get;set;} = arr;
    public List<int> Sort() {
        for (int i = 0; i < arr.Count; i++) {
            Swapper(i);
        }
        return arr;
    }
    public void Swapper(int index) {
        if (index == 0 || arr[index] > arr[index - 1]) {
            return;
        }
        int tempVal = arr[index];
        arr[index] = arr[index- 1];
        arr[index- 1] = tempVal;
        Swapper(index - 1);
    }
}