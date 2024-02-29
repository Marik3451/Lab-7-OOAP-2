using System;

class MagazineTask
{
    public string Description { get; set; }

    public MagazineTask(string description)
    {
        Description = description;
    }
}

abstract class Editor
{
    protected Editor successor;

    public void SetSuccessor(Editor successor)
    {
        this.successor = successor;
    }

    public abstract void HandleTask(MagazineTask task);
}

class EditingEditor : Editor
{
    public override void HandleTask(MagazineTask task)
    {
        if (task.Description.Contains("правки"))
        {
            Console.WriteLine($"Внесення правок до статті: {task.Description}");
        }
        else if (successor != null)
        {
            successor.HandleTask(task);
        }
    }
}

class LayoutEditor : Editor
{
    public override void HandleTask(MagazineTask task)
    {
        if (task.Description.Contains("макет"))
        {
            Console.WriteLine($"Оформлення макету: {task.Description}");
        }
        else if (successor != null)
        {
            successor.HandleTask(task);
        }
    }
}

class DesignEditor : Editor
{
    public override void HandleTask(MagazineTask task)
    {
        if (task.Description.Contains("дизайн"))
        {
            Console.WriteLine($"Створення дизайну: {task.Description}");
        }
        else if (successor != null)
        {
            successor.HandleTask(task);
        }
        else 
        {
            Console.WriteLine("Кінець");
        
    }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Editor editingEditor = new EditingEditor();
        Editor layoutEditor = new LayoutEditor();
        Editor designEditor = new DesignEditor();

        editingEditor.SetSuccessor(layoutEditor);
        layoutEditor.SetSuccessor(designEditor);

        MagazineTask task1 = new MagazineTask("Внести правки в статтю про моду");
        MagazineTask task2 = new MagazineTask("Оформити макет головної сторінки");
        MagazineTask task3 = new MagazineTask("Створити дизайн рекламного блоку");
        MagazineTask task4 = new MagazineTask("Створити  рекламного блоку");

        editingEditor.HandleTask(task1);
        editingEditor.HandleTask(task2);
        editingEditor.HandleTask(task3);
        editingEditor.HandleTask(task4);

        Console.ReadLine();
    }
}
