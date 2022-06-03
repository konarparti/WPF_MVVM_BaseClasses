# WPF_MVVM_BaseClasses
DLL с базовыми классами ViewModelBase.cs и RelayCommand.cs необходимыми для реализации паттерна MVVM в проектах WPF

Как использовать:

1. Клонируем/скачиваем репозиторий целиком или только файл bin/Debug/WPF_MVVM_Classes.dll. Нужен будет только он.
2. Закидываем в папку с проектом.
3. В обозревателе решений во вкладке ссылки добавляем ссылку на WPF_MVVM_Classes.dll в папке с проектом.
4. Пользуемся, наследуемся, реализуем по своему.


### MainWindowViewModel.cs
```csharp
public RelayCommand OpenChildCommand
        {
            get
            {
                return new RelayCommand(command =>
                {
                    var vm = new ChildWindowViewModel();
                    RegisterWindow(new ChildWindow(), vm, "Some title");
                    var win = ChildWindows[vm];
                    win.Show();
                });
            }
        }
```
### ChildWindowViewModel.cs
```csharp
public RelayCommand CloseCommand
        {
            get
            {
                return new RelayCommand(command =>
                {
                    ChildWindows[this].Close();
                });
            }
        }
```
