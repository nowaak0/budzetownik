﻿namespace Budzetownik.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Expense>? Expenses { get; set; } = new List<Expense>();
    }
}
