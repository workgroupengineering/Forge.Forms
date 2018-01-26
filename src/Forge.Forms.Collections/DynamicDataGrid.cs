﻿using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Forge.Forms.Annotations;
using Forge.Forms.DynamicExpressions;
using Forge.Forms.FormBuilding;
using Forge.Forms.FormBuilding.Defaults;
using MaterialDesignThemes.Wpf;
using Expression = System.Linq.Expressions.Expression;

namespace Forge.Forms.Collections
{
    public class DynamicDataGrid : Control
    {
        public static readonly DependencyProperty CreateDialogPositiveContentProperty =
            DependencyProperty.Register(
                nameof(CreateDialogPositiveContent),
                typeof(string),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata("ADD"));

        public string CreateDialogPositiveContent
        {
            get => (string)GetValue(CreateDialogPositiveContentProperty);
            set => SetValue(CreateDialogPositiveContentProperty, value);
        }

        public static readonly DependencyProperty CreateDialogPositiveIconProperty =
            DependencyProperty.Register(
                nameof(CreateDialogPositiveIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Check));

        public PackIconKind? CreateDialogPositiveIcon
        {
            get => (PackIconKind)GetValue(CreateDialogPositiveIconProperty);
            set => SetValue(CreateDialogPositiveIconProperty, value);
        }

        public static readonly DependencyProperty CreateDialogNegativeContentProperty = DependencyProperty.Register(
            nameof(CreateDialogNegativeContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("CANCEL"));

        public string CreateDialogNegativeContent
        {
            get => (string)GetValue(CreateDialogNegativeContentProperty);
            set => SetValue(CreateDialogNegativeContentProperty, value);
        }

        public static readonly DependencyProperty CreateDialogNegativeIconProperty =
            DependencyProperty.Register(
                nameof(CreateDialogNegativeIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Close));

        public PackIconKind? CreateDialogNegativeIcon
        {
            get => (PackIconKind)GetValue(CreateDialogNegativeIconProperty);
            set => SetValue(CreateDialogNegativeIconProperty, value);
        }

        public static readonly DependencyProperty UpdateDialogPositiveContentProperty = DependencyProperty.Register(
            nameof(UpdateDialogPositiveContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("SAVE"));

        public string UpdateDialogPositiveContent
        {
            get => (string)GetValue(UpdateDialogPositiveContentProperty);
            set => SetValue(UpdateDialogPositiveContentProperty, value);
        }

        public static readonly DependencyProperty UpdateDialogPositiveIconProperty =
            DependencyProperty.Register(
                nameof(UpdateDialogPositiveIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Check));

        public PackIconKind? UpdateDialogPositiveIcon
        {
            get => (PackIconKind)GetValue(UpdateDialogPositiveIconProperty);
            set => SetValue(UpdateDialogPositiveIconProperty, value);
        }

        public static readonly DependencyProperty UpdateDialogNegativeContentProperty = DependencyProperty.Register(
            nameof(UpdateDialogNegativeContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("CANCEL"));

        public string UpdateDialogNegativeContent
        {
            get => (string)GetValue(UpdateDialogNegativeContentProperty);
            set => SetValue(UpdateDialogNegativeContentProperty, value);
        }

        public static readonly DependencyProperty UpdateDialogNegativeIconProperty =
            DependencyProperty.Register(
                nameof(UpdateDialogNegativeIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Close));

        public PackIconKind? UpdateDialogNegativeIcon
        {
            get => (PackIconKind)GetValue(UpdateDialogNegativeIconProperty);
            set => SetValue(UpdateDialogNegativeIconProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogTitleContentProperty = DependencyProperty.Register(
            nameof(RemoveDialogTitleContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata());

        public string RemoveDialogTitleContent
        {
            get => (string)GetValue(RemoveDialogTitleContentProperty);
            set => SetValue(RemoveDialogTitleContentProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogTextContentProperty = DependencyProperty.Register(
            nameof(RemoveDialogTextContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("Remove item?"));

        public string RemoveDialogTextContent
        {
            get => (string)GetValue(RemoveDialogTextContentProperty);
            set => SetValue(RemoveDialogTextContentProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogPositiveContentProperty = DependencyProperty.Register(
            nameof(RemoveDialogPositiveContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("REMOVE"));

        public string RemoveDialogPositiveContent
        {
            get => (string)GetValue(RemoveDialogPositiveContentProperty);
            set => SetValue(RemoveDialogPositiveContentProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogPositiveIconProperty =
            DependencyProperty.Register(
                nameof(RemoveDialogPositiveIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Delete));

        public PackIconKind? RemoveDialogPositiveIcon
        {
            get => (PackIconKind)GetValue(RemoveDialogPositiveIconProperty);
            set => SetValue(RemoveDialogPositiveIconProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogNegativeContentProperty = DependencyProperty.Register(
            nameof(RemoveDialogNegativeContent),
            typeof(string),
            typeof(DynamicDataGrid),
            new FrameworkPropertyMetadata("CANCEL"));

        public string RemoveDialogNegativeContent
        {
            get => (string)GetValue(RemoveDialogNegativeContentProperty);
            set => SetValue(RemoveDialogNegativeContentProperty, value);
        }

        public static readonly DependencyProperty RemoveDialogNegativeIconProperty =
            DependencyProperty.Register(
                nameof(RemoveDialogNegativeIcon),
                typeof(PackIconKind?),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(PackIconKind.Close));

        public PackIconKind? RemoveDialogNegativeIcon
        {
            get => (PackIconKind)GetValue(RemoveDialogNegativeIconProperty);
            set => SetValue(RemoveDialogNegativeIconProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata());

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty DialogOptionsProperty =
            DependencyProperty.Register(
                nameof(DialogOptions),
                typeof(DialogOptions),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(DialogOptions.Default, ItemsSourceChanged));

        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DynamicDataGrid)d).OnItemsSource(e.NewValue);
        }

        public DialogOptions DialogOptions
        {
            get => (DialogOptions)GetValue(DialogOptionsProperty);
            set => SetValue(DialogOptionsProperty, value);
        }

        public static readonly DependencyProperty FormBuilderProperty =
            DependencyProperty.Register(
                nameof(FormBuilder),
                typeof(IFormBuilder),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata(FormBuilding.FormBuilder.Default));

        public IFormBuilder FormBuilder
        {
            get => (IFormBuilder)GetValue(FormBuilderProperty);
            set => SetValue(FormBuilderProperty, value);
        }

        public static readonly DependencyProperty TargetDialogIdentifierProperty =
            DependencyProperty.Register(
                nameof(TargetDialogIdentifier),
                typeof(object),
                typeof(DynamicDataGrid),
                new FrameworkPropertyMetadata());

        public object TargetDialogIdentifier
        {
            get => GetValue(TargetDialogIdentifierProperty);
            set => SetValue(TargetDialogIdentifierProperty, value);
        }

        #region Collection helpers

        private static readonly Dictionary<Type, Action<object, object>> AddItemCache =
            new Dictionary<Type, Action<object, object>>();

        private static readonly Dictionary<Type, Action<object, object>> RemoveItemCache =
            new Dictionary<Type, Action<object, object>>();

        private static void AddItemToCollection(Type itemType, object collection, object item)
        {
            if (!AddItemCache.TryGetValue(itemType, out var action))
            {
                var collectionType = typeof(ICollection<>).MakeGenericType(itemType);
                var addMethod = collectionType.GetMethod("Add") ?? throw new InvalidOperationException("This should not happen.");
                var collectionParam = Expression.Parameter(typeof(object), "collection");
                var itemParam = Expression.Parameter(typeof(object), "item");
                var lambda = Expression.Lambda<Action<object, object>>(
                    Expression.Call(
                        Expression.Convert(collectionParam, collectionType),
                        addMethod,
                        Expression.Convert(itemParam, itemType)),
                    collectionParam,
                    itemParam
                );

                action = lambda.Compile();
                AddItemCache[itemType] = action;
            }

            action(collection, item);
        }

        private static void RemoveItemFromCollection(Type itemType, object collection, object item)
        {
            if (!RemoveItemCache.TryGetValue(itemType, out var action))
            {
                var collectionType = typeof(ICollection<>).MakeGenericType(itemType);
                var removeMethod = collectionType.GetMethod("Remove") ?? throw new InvalidOperationException("This should not happen.");
                var collectionParam = Expression.Parameter(typeof(object), "collection");
                var itemParam = Expression.Parameter(typeof(object), "item");
                var lambda = Expression.Lambda<Action<object, object>>(
                    Expression.Call(
                        Expression.Convert(collectionParam, collectionType),
                        removeMethod,
                        Expression.Convert(itemParam, itemType)),
                    collectionParam,
                    itemParam
                );

                action = lambda.Compile();
                RemoveItemCache[itemType] = action;
            }

            action(collection, item);
        }

        #endregion

        public static readonly RoutedCommand CreateItemCommand = new RoutedCommand();
        public static readonly RoutedCommand UpdateItemCommand = new RoutedCommand();
        public static readonly RoutedCommand RemoveItemCommand = new RoutedCommand();

        public DynamicDataGrid()
        {
            CommandBindings.Add(new CommandBinding(CreateItemCommand, ExecuteCreateItem, CanExecuteCreateItem));
            CommandBindings.Add(new CommandBinding(UpdateItemCommand, ExecuteUpdateItem, CanExecuteUpdateItem));
            CommandBindings.Add(new CommandBinding(RemoveItemCommand, ExecuteRemoveItem, CanExecuteRemoveItem));
        }

        private Type itemType;
        private bool canMutate;

        private void OnItemsSource(object collection)
        {
            itemType = null;
            if (collection == null)
            {
                canMutate = false;
                return;
            }

            var interfaces = collection
                .GetType()
                .GetInterfaces()
                .Where(t =>
                    t.IsGenericType &&
                    t.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToList();

            if (interfaces.Count > 1 || interfaces.Count == 0)
            {
                canMutate = false;
                return;
            }

            var collectionType = interfaces[0];
            itemType = collectionType.GetGenericArguments()[0];
            canMutate = itemType.GetConstructor(Type.EmptyTypes) != null;
        }

        private async void ExecuteCreateItem(object sender, ExecutedRoutedEventArgs e)
        {
            if (!canMutate)
            {
                return;
            }

            var collection = ItemsSource;
            DialogResult result;
            var definition = GetCreateDefinition();
            try
            {
                result = await Show.Dialog(TargetDialogIdentifier, DialogOptions).For(definition);
            }
            catch
            {
                return;
            }

            if (result.Action is "DynamicDataGrid_CreateDialogPositive")
            {
                AddItemToCollection(itemType, collection, result.Model);
                if (!(collection is INotifyCollectionChanged))
                {
                    RefreshItemsView();
                }
            }
        }

        private void CanExecuteCreateItem(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = canMutate;
        }

        private async void ExecuteUpdateItem(object sender, ExecutedRoutedEventArgs e)
        {
            var model = e.Parameter;
            if (!canMutate || model == null || !itemType.IsInstanceOfType(model))
            {
                return;
            }

            DialogResult result;
            var definition = GetUpdateDefinition(model);
            try
            {
                result = await Show
                    .Dialog(TargetDialogIdentifier, DialogOptions)
                    .For((IFormDefinition)definition);
            }
            catch
            {
                return;
            }

            if (result.Action is "DynamicDataGrid_UpdateDialogNegative")
            {
                definition.Snapshot.Apply(model);
            }
        }

        private void CanExecuteUpdateItem(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = canMutate && e.Parameter != null && itemType.IsInstanceOfType(e.Parameter);
        }

        private async void ExecuteRemoveItem(object sender, ExecutedRoutedEventArgs e)
        {
            if (!canMutate || e.Parameter == null)
            {
                return;
            }

            try
            {
                var result = await Show
                    .Dialog(TargetDialogIdentifier, DialogOptions)
                    .For(new Confirmation(
                        RemoveDialogTextContent,
                        RemoveDialogTitleContent,
                        RemoveDialogPositiveContent,
                        RemoveDialogNegativeContent
                    )
                    {
                        PositiveActionIcon = RemoveDialogPositiveIcon,
                        NegativeActionIcon = RemoveDialogNegativeIcon
                    });

                if (result.Action is "positive")
                {
                    RemoveItemFromCollection(itemType, ItemsSource, e.Parameter);
                }
            }
            catch
            {
                return;
            }
        }

        private void CanExecuteRemoveItem(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = canMutate && e.Parameter != null;
        }

        private void RefreshItemsView()
        {
            throw new NotImplementedException();
        }

        private IFormDefinition GetCreateDefinition()
        {
            throw new NotImplementedException();
        }

        private UpdateFormDefinition GetUpdateDefinition(object model)
        {
            throw new NotImplementedException();
        }

        //private async Task AddNewItem(object collection, IModelInputProvider input, Type subType)
        //{
        //    if (collection == null)
        //    {
        //        throw new ArgumentNullException(nameof(collection));
        //    }

        //    var interfaces = collection
        //        .GetType()
        //        .GetInterfaces()
        //        .Where(t =>
        //            t.IsGenericType &&
        //            t.GetGenericTypeDefinition() == typeof(ICollection<>))
        //        .ToList();

        //    if (interfaces.Count > 1)
        //    {
        //        throw new InvalidOperationException("Multiple implementations of ICollection<T> found.");
        //    }

        //    if (interfaces.Count == 0)
        //    {
        //        throw new InvalidOperationException("No implementation of ICollection<T> found.");
        //    }

        //    var collectionType = interfaces[0];
        //    var itemType = collectionType.GetGenericArguments()[0];
        //    object item;
        //    if (subType != null)
        //    {
        //        if (!itemType.IsAssignableFrom(subType))
        //        {
        //            throw new InvalidOperationException($"Type {subType} cannot be assigned to {itemType}");
        //        }

        //        item = Activator.CreateInstance(subType);
        //    }
        //    else
        //    {
        //        item = Activator.CreateInstance(itemType);
        //    }

        //    var positive = await input.ShowDialog(item);
        //    if (!positive)
        //    {
        //        return;
        //    }

        //    AddItem(itemType, collection, item);
        //}

        private FormRow GetCreateActions(IFormDefinition formDefinition)
        {
            return new FormRow(true, 1)
            {
                Elements =
                {
                    new FormElementContainer(0, formDefinition.Grid.Length, new ActionElement
                    {
                        Action = new LiteralValue("DynamicDataGrid_Create"),
                        Content = new LiteralValue("CREATE" /* TODO Customize from grid */),
                        ClosesDialog = LiteralValue.True,
                        ActionInterceptor = new LiteralValue(new ActionInterceptor(ctx =>
                        {
                            // TODO: handle create
                            return ctx;
                        })),
                        ActionParameter = new LiteralValue(null /* TODO */)
                    }),
                    new FormElementContainer(0, formDefinition.Grid.Length, new ActionElement
                    {
                        Action = new LiteralValue("DynamicDataGrid_Create"),
                        Content = new LiteralValue("CANCEL" /* TODO Customize from grid */),
                        ClosesDialog = LiteralValue.True,
                        ActionInterceptor = new LiteralValue(new ActionInterceptor(ctx =>
                        {
                            // TODO: handle cancel
                            return ctx;
                        })),
                        ActionParameter = new LiteralValue(null /* TODO */)
                    })
                }
            };
        }

        private IFormDefinition AddRows(
            IFormDefinition formDefinition,
            params FormRow[] rows)
        {
            return new FormDefinitionWrapper(
                formDefinition,
                formDefinition.FormRows.Concat(rows ?? new FormRow[0]).ToList().AsReadOnly());
        }
    }

    internal class ActionInterceptor : IActionInterceptor
    {
        private readonly Func<IActionContext, IActionContext> onAction;

        public ActionInterceptor(Func<IActionContext, IActionContext> onAction)
        {
            this.onAction = onAction ?? throw new ArgumentNullException(nameof(onAction));
        }


        public IActionContext InterceptAction(IActionContext actionContext)
        {
            return onAction(actionContext);
        }
    }

    internal class FormDefinitionWrapper : IFormDefinition
    {
        private readonly IFormDefinition inner;

        public FormDefinitionWrapper(IFormDefinition inner, IReadOnlyList<FormRow> formRows)
        {
            this.inner = inner;
            FormRows = formRows;
        }

        public IReadOnlyList<FormRow> FormRows { get; }

        public double[] Grid
        {
            get => inner.Grid;
            set => inner.Grid = value;
        }

        public Type ModelType => inner.ModelType;

        public IDictionary<string, IValueProvider> Resources => inner.Resources;

        public object CreateInstance(IResourceContext context)
        {
            return inner.CreateInstance(context);
        }
    }

    internal class UpdateFormDefinition : IFormDefinition
    {
        private readonly IFormDefinition inner;

        public UpdateFormDefinition(
            IFormDefinition inner,
            object model,
            IReadOnlyList<FormRow> formRows)
        {
            this.inner = inner;
            FormRows = formRows;
            Model = model;
            Snapshot = new Snapshot(model, new HashSet<string>(formRows
                .SelectMany(r => r.Elements.SelectMany(e => e.Elements))
                .Where(e => e is DataFormField)
                .Select(f => ((DataFormField)f).Key)));
        }

        public object Model { get; }

        public Snapshot Snapshot { get; }

        public IReadOnlyList<FormRow> FormRows { get; }

        public double[] Grid
        {
            get => inner.Grid;
            set => inner.Grid = value;
        }

        public Type ModelType => inner.ModelType;

        public IDictionary<string, IValueProvider> Resources => inner.Resources;

        public object CreateInstance(IResourceContext context)
        {
            return Model;
        }
    }
}
