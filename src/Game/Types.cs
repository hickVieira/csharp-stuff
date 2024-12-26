using Newtonsoft.Json;

namespace Game;

public struct GUID : I.Serializable
{
    public string SerializeToJson() => Serde.Serialize.ToJson(this);

    public uint id { get; set; } = 0;

    public GUID() => this.id = 0;
    public GUID(uint id) => this.id = id;
    public static GUID None { get => new GUID(0); }
}

public struct Ref<T> : I.Serializable where T : Core.Entity
{
    public string SerializeToJson() => Serde.Serialize.ToJson(this);

    public uint id { get; set; } = 0;
    [JsonIgnore] public T _entity;
    [JsonIgnore] public T entity { get { if (_entity == null) _entity = Game.State.Get<T>(guid); return _entity; } private set => _entity = value; }
    [JsonIgnore] public GUID guid { get => new GUID(this.id); }

    public Ref() => (this.id, this.entity) = (0, default);
    public Ref(uint id) => (this.id, this.entity) = (id, default);
    public Ref(uint id, T obj) => (this.id, this.entity) = (id, obj);
    public static Ref<T> None { get => new Ref<T>(0, default); }
}

public readonly struct Either<TLeft, TRight>
{
    private readonly TLeft _left;
    private readonly TRight _right;
    private readonly bool _isLeft;

    public bool IsLeft => _isLeft;
    public bool IsRight => !_isLeft;
    public TLeft Left => _isLeft ? _left : throw new System.InvalidOperationException("Accessing Left value when it is Right.");
    public TRight Right => !_isLeft ? _right : throw new System.InvalidOperationException("Accessing Right value when it is Left.");

    public TResult Match<TResult>(System.Func<TLeft, TResult> onLeft, System.Func<TRight, TResult> onRight) => _isLeft ? onLeft(_left) : onRight(_right);
    public override string ToString() => _isLeft ? $"Left({_left})" : $"Right({_right})";

    public Either(TLeft left)
    {
        _left = left;
        _right = default!;
        _isLeft = true;
    }

    public Either(TRight right)
    {
        _left = default!;
        _right = right;
        _isLeft = false;
    }
}


public static partial class _
{
    public static Ref<T> Ref<T>(this T obj) where T : Core.Entity => new Ref<T>(obj.guid.id, obj);
    public static string FullName(this object o) => o.GetType().FullName;
}
