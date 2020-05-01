// @author LarsVomMars
// https://github.com/LarsVomMars/Checkboxes

using System;
using System.Collections.Generic;

namespace Checkbox
{
    public class Checkbox
    {
        private List<CheckboxOptions> _options;
        private int _hoveredIndex;
        private int _selectedIndex;
        private string _displayText;
        private bool _multiSelect;
        private bool _required;
        private bool _error;
        private ConsoleKey _key;
        private ConsoleKey _prevKey;

        public Checkbox(string displayText, params string[] options)
        {
            _multiSelect = false;
            _required = true;
            Init(displayText, options);
        }

        public Checkbox(string displayText, bool multiMode, bool required, params string[] options)
        {
            _multiSelect = multiMode;
            _required = required;
            Init(displayText, options);
        }

        private void Init(string dt, string[] options)
        {
            _hoveredIndex = 0;
            _selectedIndex = -1;
            _error = false;
            _displayText = dt;

            _options = new List<CheckboxOptions>();

            for (int i = 0; i < options.Length; i++)
                _options.Add(new CheckboxOptions(options[i], false, i == _hoveredIndex, i));
        }

        private CheckboxReturn[] ReturnData()
        {
            List<CheckboxReturn> l = new List<CheckboxReturn>();
            foreach (var option in _options)
            {
                if (option.Selected) l.Add(option.GetData());
            }

            return l.ToArray();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(_displayText);
            Console.WriteLine("(Use Arrow keys to navigate up and down, Space bar to select and Enter to submit)");

            foreach (var option in _options)
            {
                Console.ForegroundColor = option.Selected
                    ? (option.Hovered ? ConsoleColor.Blue : ConsoleColor.DarkBlue)
                    : (option.Hovered ? ConsoleColor.White : ConsoleColor.DarkGray);
                
                Console.WriteLine((option.Selected ? "[*]~ " : "[ ]~ ") + $"{option.Option}");
            }
            Console.ResetColor();
            if (_error) Console.WriteLine("\nAt least one item has to be selected!");
        }

        public CheckboxReturn[] Select()
        {
            Show();
            bool end = false;
            while (!end)
            {
                _key = Console.KeyAvailable ? Console.ReadKey(true).Key : ConsoleKey.D9;
                if (_key == _prevKey) continue;
                _options[_hoveredIndex].Hovered = false;

                switch (_key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        _hoveredIndex = _hoveredIndex - 1 >= 0 ? _hoveredIndex - 1 : _options.Count - 1;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        _hoveredIndex = _hoveredIndex + 1 < _options.Count ? _hoveredIndex + 1 : 0;
                        break;

                    case ConsoleKey.Spacebar:
                        _options[_hoveredIndex].Selected = !_options[_hoveredIndex].Selected;
                        if (!_multiSelect)
                        {
                            if (_selectedIndex > -1 && _hoveredIndex != _selectedIndex)
                                _options[_selectedIndex].Selected = false;
                            _selectedIndex = _hoveredIndex;
                        }

                        _error = false;
                        break;

                    case ConsoleKey.Enter:
                        if (_required)
                        {
                            foreach (var option in _options)
                            {
                                if (!option.Selected) continue;
                                end = true;
                                break;
                            }

                            if (!end) _error = true;
                        }
                        else end = true;

                        break;
                }

                _options[_hoveredIndex].Hovered = true;
                Show();
                _prevKey = _key;
            }

            return ReturnData();
        }
    }

    public class CheckboxOptions
    {
        private readonly int _index;
        private readonly string _option;

        public CheckboxOptions(string option, bool selected, bool hovered, int index)
        {
            _option = option;
            Selected = selected;
            Hovered = hovered;
            _index = index;
        }

        public bool Selected { get; set; }

        public bool Hovered { get; set; }

        public string Option => _option;

        public CheckboxReturn GetData()
        {
            return new CheckboxReturn(_index, _option);
        }
    }

    public class CheckboxReturn
    {
        private int _index;
        private string _option;

        public CheckboxReturn(int index, string option)
        {
            _index = index;
            _option = option;
        }

        public int Index => _index;

        public string Option => _option;
    }
}