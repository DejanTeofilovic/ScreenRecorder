﻿using System.Collections;
using System.Collections.Generic;

namespace Captura.Models
{
    public class GifWriterProvider : NotifyPropertyChanged, IVideoWriterProvider
    {
        readonly LanguageManager _loc;
        readonly GifItem _gifItem;

        public GifWriterProvider(LanguageManager Loc, GifItem GifItem)
        {
            _loc = Loc;
            _gifItem = GifItem;

            _loc.LanguageChanged += L => RaisePropertyChanged(nameof(Name));
        }
        
        public string Name => _loc.Gif;

        public IEnumerator<IVideoWriterItem> GetEnumerator()
        {
            yield return _gifItem;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => Name;
    }
}
