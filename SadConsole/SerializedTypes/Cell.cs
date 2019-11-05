﻿using System.Linq;
using System.Runtime.Serialization;

namespace SadConsole.SerializedTypes
{
    [DataContract]
    public class CellSerialized
    {
        [DataMember]
        public CellDecorator[] Decorators;

        [DataMember]
        public ColorSerialized Foreground;

        [DataMember]
        public ColorSerialized Background;

        [DataMember]
        public int Glyph;

        [DataMember]
        public Mirror Mirror;

        [DataMember]
        public bool IsVisible;

        [DataMember]
        public CellStateSerialized CellState;

        public static implicit operator CellSerialized(Cell cell) => new CellSerialized()
        {
            Foreground = cell.Foreground,
            Background = cell.Background,
            Glyph = cell.Glyph,
            IsVisible = cell.IsVisible,
            Mirror = cell.Mirror,
            Decorators = cell.Decorators,
            CellState = cell.State
        };

        public static implicit operator Cell(CellSerialized cell)
        {
            var newCell = new Cell(cell.Foreground, cell.Background, cell.Glyph, cell.Mirror)
            {
                IsVisible = cell.IsVisible,
                Decorators = cell.Decorators.Length != 0 ? cell.Decorators.ToArray() : System.Array.Empty<CellDecorator>()
            };

            if (cell.CellState != null)
            {
                newCell.State = cell.CellState;
            }

            return newCell;
        }
    }

    [DataContract]
    public class CellStateSerialized
    {
        [DataMember]
        public CellDecorator[] Decorators;

        [DataMember]
        public ColorSerialized Foreground;

        [DataMember]
        public ColorSerialized Background;

        [DataMember]
        public int Glyph;

        [DataMember]
        public Mirror Mirror;

        [DataMember]
        public bool IsVisible = true;

        public static implicit operator CellStateSerialized(CellState cell) => new CellStateSerialized()
        {
            Foreground = cell.Foreground,
            Background = cell.Background,
            Glyph = cell.Glyph,
            IsVisible = cell.IsVisible,
            Mirror = cell.Mirror,
            Decorators = cell.Decorators
        };

        public static implicit operator CellState(CellStateSerialized cell) => new CellState(cell.Foreground, cell.Background, cell.Glyph, cell.Mirror,
                                 cell.IsVisible, cell.Decorators.Length != 0 ? cell.Decorators.ToArray() : System.Array.Empty<CellDecorator>());
    }
}