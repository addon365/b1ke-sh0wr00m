export interface IDictionary<T> {
  add(key: string, value: T): void;
  remove(key: string): void;
  containsKey(key: string): boolean;
  keys(): Array<string>;
  values(): Array<T>;
  get(key: string): T;
}

export class Dictionary<T> {
  _keys: string[] = new Array<string>();
  _values: T[] = new Array<T>();

  get(key: string): T {
    return this[key];
  }

  add(key: string, value: T) {
    this[key] = value;
    this._keys.push(key);
    this._values.push(value);
  }

  remove(key: string) {
    var index = this._keys.indexOf(key, 0);
    this._keys.splice(index, 1);
    this._values.splice(index, 1);

    delete this[key];
  }

  keys(): string[] {
    return this._keys;
  }

  values(): any[] {
    return this._values;
  }

  containsKey(key: string) {
    if (typeof this[key] === "undefined") {
      return false;
    }

    return true;
  }

  toLookup(): IDictionary<T> {
    return this;
  }
}
