public struct ResourceBar {
	public int Size { get; private set; }

	private int currentValue;

	public int CurrentValue {
		get => currentValue;
		set {
			if (value < 0) {
				value = 0;
			}

			if (value > Size) {
				value = Size;
			}

			currentValue = value;
		}
	}

	public float Ratio => (float) CurrentValue / Size;

	public bool Full => CurrentValue == Size;
	public bool Empty => CurrentValue == 0;

	public ResourceBar(int size) {
		Size = size;
		currentValue = size;
	}

	public void SetSize(int size, bool fill) {
		Size = size;
		if (fill || CurrentValue > size) CurrentValue = size;
	}

	public override string ToString() {
		return $"{CurrentValue}/{Size}";
	}
}