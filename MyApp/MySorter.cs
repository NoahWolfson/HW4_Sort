class MySorter(List<int> arr) {
    private List<int> arr {get;set;} = arr;

    public List<int> Sort()
    {
        int divider = arr.Count / (int)Math.Round(Math.Log2(arr.Count));
        int num_of_dividers = (int)Math.Round(Math.Log2(arr.Count));
        ContainerSizedSwapper(0, divider);
        ContainerSizedSwapper(0, divider - 1);
        List<int> newArr = SectionSort(divider, num_of_dividers);
        SelectionSort selectionSort = new SelectionSort(newArr);
        newArr = selectionSort.Sort();
        return selectionSort.Sort();
    }
    private void ContainerSizedSwapper(int startIndex, int endIndex) {
        if (endIndex == arr.Count) {
            return;
        }
        if (arr[startIndex] > arr[endIndex]) {
            int tempVal = arr[startIndex];
            arr[startIndex] = arr[endIndex];
            arr[endIndex] = tempVal;
        }
        ContainerSizedSwapper(startIndex + 1, endIndex + 1);
    }
    private List<int> SectionSort(int divider, int num_of_dividers)
    {
        Dictionary<int, List<int>> sectionAmmount = new Dictionary<int, List<int>>();
        List<int> newArr = new List<int>();
        for (int i = 0; i < num_of_dividers; i++)
        {
            if (i + 1 == num_of_dividers) {
                int newDivider = arr.Count - i * divider;
                sectionAmmount.Add(getTotal(i * divider, i * divider + divider), arr.GetRange(i * divider, newDivider));
            } else {
            sectionAmmount.Add(getTotal(i * divider, i * divider + divider), arr.GetRange(i * divider, divider));
            }
        }
        newArr = sectionAmmount.OrderBy(key => key.Key).SelectMany(key => key.Value).ToList();
        return newArr;
    }

    private int getTotal(int arrPeice1Start, int arrPeice1End) {
        int total = 0;
        for (int i = arrPeice1Start; i < arrPeice1End; i++) {
            try {
                total += arr[i];
            } catch (IndexOutOfRangeException) {
                break;
            }

        }
        return total;
    }
}