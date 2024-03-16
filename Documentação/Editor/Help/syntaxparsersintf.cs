#region Copyright (c) 2004 - 2007 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Common.NET Library

	Copyright (c) 2004 - 2007 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 - 2007 Quantum Whale LLC.

using System;
using System.Collections;
using System.Reflection;

namespace QWhale.Syntax.Parsers
{
	#region .NET NodeType
	/// <summary>
	/// Defines types of syntax nodes used to create a hierarchical tree view that examines code text as a collection of syntax members.
	/// Intendent to use with collection of .NET languages, like C#, J#, and VB.NET
	/// </summary>
	public enum NetNodeType
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None,
		// declarations
		/// <summary>
		/// Specifies that syntax node corresponds to entire unit.
		/// </summary>
		Unit,
		/// <summary>
		/// Specifies that syntax node corresponds to the list of external namespaces.
		/// </summary>
		UsingList,
		/// <summary>
		/// Specifies that syntax node corresponds to external namespace.
		/// </summary>
		Using,
		/// <summary>
		/// Specifies that syntax node corresponds to user-defined symbol representing a namespace.
		/// </summary>
		UsingAlias,
		/// <summary>
		/// Specifies that syntax node corresponds to external alias directive.
		/// </summary>
		Alias,
		/// <summary>
		/// Specifies that syntax node corresponds to the list of external alias directives.
		/// </summary>
		AliasList,
		/// <summary>
		/// Specifies that syntax node corresponds to namespace.
		/// </summary>
		Namespace,
		/// <summary>
		/// Specifies that syntax node corresponds to class.
		/// </summary>
		Class,
		/// <summary>
		/// Specifies that syntax node corresponds to structure.
		/// </summary>
		Struct,
		/// <summary>
		/// Specifies that syntax node corresponds to interface.
		/// </summary>
		Interface,
		/// <summary>
		/// Specifies that syntax node corresponds to enumeration.
		/// </summary>
		Enum,
		/// <summary>
		/// Specifies that syntax node corresponds to module.
		/// </summary>
		Module,
		/// <summary>
		/// Specifies that syntax node corresponds to field.
		/// </summary>
		Field,
		/// <summary>
		/// Specifies that syntax node corresponds to constant.
		/// </summary>
		Constant,
		/// <summary>
		/// Specifies that syntax node corresponds to local variable.
		/// </summary>
		LocalVariable,
		/// <summary>
		/// Specifies that syntax node corresponds to fixed variable.
		/// </summary>
		FixedVariable,
		/// <summary>
		/// Specifies that syntax node corresponds to method.
		/// </summary>
		Method,
		/// <summary>
		/// Specifies that syntax node corresponds to constructor.
		/// </summary>
		Constructor,
		/// <summary>
		/// Specifies that syntax node corresponds to destructor.
		/// </summary>
		Destructor,
		/// <summary>
		/// Specifies that syntax node corresponds to delegate.
		/// </summary>
		Delegate,
		/// <summary>
		/// Specifies that syntax node corresponds to property.
		/// </summary>
		Property,
		/// <summary>
		/// Specifies that syntax node corresponds to event.
		/// </summary>
		Event,
		/// <summary>
		/// Specifies that syntax node corresponds to operator.
		/// </summary>
		Operator,
		/// <summary>
		/// Specifies that syntax node corresponds to operator type.
		/// </summary>
		OperatorType,
		/// <summary>
		/// Specifies that syntax node corresponds to indexer.
		/// </summary>
		Indexer,
		/// <summary>
		/// Specifies that syntax node corresponds to parameter.
		/// </summary>
		Parameter,
		/// <summary>
		/// Specifies that syntax node corresponds to list of parameters.
		/// </summary>
		ParameterList,
		/// <summary>
		/// Specifies that syntax node corresponds to method argument.
		/// </summary>
		Argument, 
		/// <summary>
		/// Specifies that syntax node corresponds to list of arguments.
		/// </summary>
		ArgumentList, 
		/// <summary>
		/// Specifies that syntax node corresponds to attribute.
		/// </summary>
		Attribute,
		/// <summary>
		/// Specifies that syntax node corresponds to list of attributes.
		/// </summary>
		AttributeList,
		/// <summary>
		/// Specifies that syntax node corresponds to target of attribute.
		/// </summary>
		AttributeTarget,
		/// <summary>
		/// Specifies that syntax node corresponds to name (identifier).
		/// </summary>
		Name,
		/// <summary>
		/// Specifies that syntax node corresponds to type.
		/// </summary>
		Type,
		/// <summary>
		/// Specifies that syntax node corresponds to accessor of property.
		/// </summary>
		PropertyAccessor,
		/// <summary>
		/// Specifies that syntax node corresponds to accessor of event.
		/// </summary>
		EventAccessor,
		/// <summary>
		/// Specifies that syntax node corresponds to access modifier.
		/// </summary>
		Modifier,
		/// <summary>
		/// Specifies that syntax node corresponds to array modifier.
		/// </summary>
		ArrayModifier,
		/// <summary>
		/// Specifies that syntax node corresponds to region.
		/// </summary>
		Region,
		/// <summary>
		/// Specifies that syntax node corresponds to parameter modifier.
		/// </summary>
		ParameterModifier,
		/// <summary>
		/// Specifies that syntax node corresponds to default parameter.
		/// </summary>
		OptionalParameter,
		/// <summary>
		/// Specifies that syntax attribute corresponds to array specifier.
		/// </summary>
		ArraySpecifier,
		/// <summary>
		/// Specifies that syntax node corresponds to local constant.
		/// </summary>
		LocalConst,
		/// <summary>
		/// Specifies that syntax node corresponds to language statement.
		/// </summary>
		Statement,
		/// <summary>
		/// Specifies that syntax node corresponds to list of types.
		/// </summary>
		TypeList,
		/// <summary>
		/// Specifies that syntax node corresponds to list of handles (procedure that handles some event).
		/// </summary>
		HandlesList,
		/// <summary>
		/// Specifies that syntax node corresponds to list of implements (interface implemented in the class).
		/// </summary>
		ImplementsList,
		/// <summary>
		/// Specifies that syntax node corresponds to list of exception that can be handled by a method.
		/// </summary>
		ThrowsList,
		/// <summary>
		/// Specifies that syntax node corresponds to comment.
		/// </summary>
		Comment,
		

		// C# 2.0
		/// <summary>
		/// Specifies that syntax node corresponds to generic type.
		/// </summary>
		TypeParameter,
		/// <summary>
		/// Specifies that syntax node corresponds to list of generic type.
		/// </summary>
		TypeParameterList,
		/// <summary>
		/// Specifies that syntax node corresponds to parameter constraint.
		/// </summary>
		TypeParameterConstraint,
		/// <summary>
		/// Specifies that syntax node corresponds to list of parameter constraints.
		/// </summary>
		TypeParameterConstraintsClauseList,
		/// <summary>
		/// Specifies that syntax node corresponds to parameter constraint clause.
		/// </summary>
		TypeParameterConstraintsClause,
		// xml

		/// <summary>
		/// Specifies that syntax node corresponds to xml comment.
		/// </summary>
		XmlComment,
		/// <summary>
		/// Specifies that syntax node corresponds to xml unit.
		/// </summary>
		XmlUnit,
		/// <summary>
		/// Specifies that syntax node corresponds to xml tag.
		/// </summary>
		XmlTag,
		/// <summary>
		/// Specifies that syntax node corresponds to xml parameter.
		/// </summary>
		XmlParameter,
		/// <summary>
		/// Specifies that syntax node corresponds to list of xml parameters.
		/// </summary>
		XmlParameterList,
		/// <summary>
		/// Specifies that syntax node corresponds to xml body.
		/// </summary>
		XmlBody,
	
		//statements
		/// <summary>
		/// Specifies that syntax node corresponds to declaration of local constant.
		/// </summary>
		LocalConstantDeclarationStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to declaration of fixed variable.
		/// </summary>
		FixedDeclarationStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "if" statement.
		/// </summary>
		IfStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "else" statement.
		/// </summary>
		ElseStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "switch" statement.
		/// </summary>
		SwitchStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "switch" section statement.
		/// </summary>
		SwitchSectionStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "switch" label statement.
		/// </summary>
		SwitchLabelStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "while" statement.
		/// </summary>
		WhileStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "do" statement.
		/// </summary>
		DoStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "do while" statement.
		/// </summary>
		DoWhileStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" statement.
		/// </summary>
		ForStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" condition statement.
		/// </summary>
		ForConditionStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" initializer statement.
		/// </summary>
		ForInitializerStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" iterator statement.
		/// </summary>
		ForIteratorStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for each" statement.
		/// </summary>
		ForEachStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for each" initializer statement.
		/// </summary>
		ForEachInitializerStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" var control statement.
		/// </summary>
		ForVarControlStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "for" var control rest statement.
		/// </summary>
		ForVarControlRestStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to variable declarators rest statement.
		/// </summary>
		VariableDeclaratorsRestStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "Annotation".
		/// </summary>
		Annotation,
		/// <summary>
		/// Specifies that syntax node corresponds to "Element Value Pair".
		/// </summary>
		ElementValuePair,
		/// <summary>
		/// Specifies that syntax node corresponds to "assert" statement.
		/// </summary>
		AssertStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "synchronized" statement.
		/// </summary>
		SynchronizedStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to variable modifier.
		/// </summary>
		VariableModifier,
		/// <summary>
		/// Specifies that syntax node corresponds to list of variable modifiers.
		/// </summary>
		VariableModifierList,
		/// <summary>
		/// Specifies that syntax node corresponds to list of variable declarator rest.
		/// </summary>
		VariableDeclaratorsRest,
		/// <summary>
		/// Specifies that syntax node corresponds to "break" statement.
		/// </summary>
		BreakStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "continue" statement.
		/// </summary>
		ContinueStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "goto" statement.
		/// </summary>
		GotoStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "return" statement.
		/// </summary>
		ReturnStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "throw" statement.
		/// </summary>
		ThrowStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "try" statement.
		/// </summary>
		TryStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "catch" statement.
		/// </summary>
		CatchStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "finally" statement.
		/// </summary>
		FinallyStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "checked" statement.
		/// </summary>
		CheckedStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "unchecked" statement.
		/// </summary>
		UncheckedStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "unsafe" statement.
		/// </summary>
		UnsafeStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "lock" statement.
		/// </summary>
		LockStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "using" statement.
		/// </summary>
		UsingStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "fixed" statement.
		/// </summary>
		FixedStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "labeled" statement.
		/// </summary>
		LabeledStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "block" statement.
		/// </summary>
		BlockStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to expression statement.
		/// </summary>
		ExpressionStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "yield" statement.
		/// </summary>
		YieldStatement,
		
		// vb
		/// <summary>
		/// Specifies that syntax node corresponds to "add handler" statement.
		/// </summary>
		AddHandlerStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "call" statement.
		/// </summary>
		CallStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "case" statement.
		/// </summary>
		CaseStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "case else" statement.
		/// </summary>
		CaseElseStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "else if" statement.
		/// </summary>
		ElseIfStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "end" statement.
		/// </summary>
		EndStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "erase" statement.
		/// </summary>
		EraseStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "error" statement.
		/// </summary>
		ErrorStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "exit" statement.
		/// </summary>
		ExitStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "mid assignment" statement.
		/// </summary>
		MidAssignmentStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "on error" statement.
		/// </summary>
		OnErrorStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "raise event" statement.
		/// </summary>
		RaiseEventStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "redim" statement.
		/// </summary>
		RedimStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "remove handler" statement.
		/// </summary>
		RemoveHandlerStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "resume" statement.
		/// </summary>
		ResumeStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "select" statement.
		/// </summary>
		SelectStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "stop" statement.
		/// </summary>
		StopStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "synclock" statement.
		/// </summary>
		SyncLockStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "with" statement.
		/// </summary>
		WithStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to with member.
		/// </summary>
		WithStatementMember,
		/// <summary>
		/// Specifies that syntax node corresponds to "empty" statement.
		/// </summary>
		EmptyStatement,


		//expressions

		/// <summary>
		/// Specifies that syntax node corresponds to expression list.
		/// </summary>
		ExpressionList,
		/// <summary>
		/// Specifies that syntax node corresponds to expression.
		/// </summary>
		Expression,
		/// <summary>
		/// Specifies that syntax node corresponds to "conditional" expression.
		/// </summary>
		ConditionalExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "assignment" expression.
		/// </summary>
		AssignmentExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "conditional or" expression.
		/// </summary>
		ConditionalOrExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "conditional and" expression.
		/// </summary>
		ConditionalAndExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "inclusive or" expression.
		/// </summary>
		InclusiveOrExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "exclusive or" expression.
		/// </summary>
		ExclusiveOrExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "and" expression.
		/// </summary>
		AndExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "not" expression.
		/// </summary>
		NotExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "equality" expression.
		/// </summary>
		EqualityExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "relation" expression.
		/// </summary>
		RelationalExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "as is" expression.
		/// </summary>
		AsIsExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "shift" expression.
		/// </summary>
		ShiftExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "additive" expression.
		/// </summary>
		AdditiveExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "multiplicative" expression.
		/// </summary>
		MultiplicativeExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "prefixed unary" expression.
		/// </summary>
		PrefixedUnaryExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "unary" expression.
		/// </summary>
		UnaryExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "cast" expression.
		/// </summary>
		CastExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "cast invocation" expression.
		/// </summary>
		CastInvocationExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "cast invocation target" expression.
		/// </summary>
		CastInvocationTargetExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "cast target" expression.
		/// </summary>
		CastTargetExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "primary" expression.
		/// </summary>
		PrimaryExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "array creation" expression.
		/// </summary>
		ArrayCreationExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "object creation" expression.
		/// </summary>
		ObjectCreationExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "array initializer" expression.
		/// </summary>
		ArrayInitializerExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "base access" expression.
		/// </summary>
		BaseAccessExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "this access" expression.
		/// </summary>
		ThisAccessExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "member access" expression.
		/// </summary>
		MemberAccessExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "pointer member access" expression.
		/// </summary>
		PointerMemberAccessExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "element access" expression.
		/// </summary>
		ElementAccessExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "invocation" expression.
		/// </summary>
		InvocationExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "checked" expression.
		/// </summary>
		CheckedExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "unchecked" expression.
		/// </summary>
		UncheckedExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "typeof" expression.
		/// </summary>
		TypeofExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "sizeof" expression.
		/// </summary>
		SizeofExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "parenthesized" expression.
		/// </summary>
		ParenthesizedExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "post increment" expression.
		/// </summary>
		PostIncrementExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "post decrement" expression.
		/// </summary>
		PostDecrementExpression,
		
		//c# 2.0
		/// <summary>
		/// Specifies that syntax node corresponds to "default" expression.
		/// </summary>
		DefaultExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "generic" expression.
		/// </summary>
		GenericExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "anonymous method" expression.
		/// </summary>
		AnonymousMethodExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "null coalescing" expression.
		/// </summary>
		NullCoalescingExpression,
		
		//vb
		/// <summary>
		/// Specifies that syntax node corresponds to "addressof" expression.
		/// </summary>
		AddressofExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "gettype" expression.
		/// </summary>
		GetTypeExpression,

		//VB,
		/// <summary>
		/// Specifies that syntax node corresponds to Option statement.
		/// </summary>
		OptionStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to equality or assignment expression.
		/// </summary>
		EqualityOrAssignmentExpression,
		/// <summary>
		/// Specifies that syntax node corresponds extern
		/// </summary>
		Extern,

		// Java
		/// <summary>
		/// Specifies that syntax node corresponds to enum body.
		/// </summary>
		EnumBody,
		// Java
		/// <summary>
		/// Specifies that syntax node corresponds to type declaration
		/// </summary>
		TypeDeclaration,

		// JScript.NET

		/// <summary>
		/// Specifies that syntax node corresponds to "delete" expression.
		/// </summary>
		DeleteExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "instanceof" expression.
		/// </summary>
		InstanceOfExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "function prototype" expression.
		/// </summary>
		PrototypeExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "type definition" expression.
		/// </summary>
		TypeExpression,
		/// <summary>
		/// Specifies that syntax node corresponds to "regular" expression.
		/// </summary>
		RegularExpression,

		//VbScript
		/// <summary>
		/// Specifies that syntax node corresponds to "Execute" statement.
		/// </summary>
		Execute,
		/// <summary>
		/// Specifies that syntax node corresponds to "ExecuteGlobal" statement.
		/// </summary>
		ExecuteGlobal,
		/// <summary>
		/// Specifies that syntax node corresponds to "Randomize" statement.
		/// </summary>
		Randomize,
		/// <summary>
		/// Specifies that syntax node corresponds to "Set" statement.
		/// </summary>
		SetStatement,
		/// <summary>
		/// Specifies that syntax node corresponds to "Imp" expression.
		/// </summary>
		ImpExpression
	}
	/// <summary>
	/// Definex types of xml comment elements.
	/// </summary>
	public enum XmlCommentType
	{
		/// <summary>
		/// Specifies "code" tag.
		/// </summary>
		C,
		/// <summary>
		/// Specifies "paragraf" tag.
		/// </summary>
		Para,
		/// <summary>
		/// Specifies "see" (link to another code element in the text) tag.
		/// </summary>
		See,
		/// <summary>
		/// Specifies "code" tag.
		/// </summary>
		Code,
		/// <summary>
		/// Specifies "parameter" tag.
		/// </summary>
		Param,
		/// <summary>
		/// Specifies "see also" (link to another element in the See Also section) tag.
		/// </summary>
		Seealso,
		/// <summary>
		/// Specifies example tag.
		/// </summary>
		Example,
		/// <summary>
		/// Specifies "parameter reference" tag.
		/// </summary>
		Paramref,
		/// <summary>
		/// Specifies "summary" tag.
		/// </summary>
		Summary,
		/// <summary>
		/// Specifies "exception" tag.
		/// </summary>
		Exception,
		/// <summary>
		/// Specifies "permission" tag.
		/// </summary>
		Permission,
		/// <summary>
		/// Specifies "value" tag.
		/// </summary>
		Value,
		/// <summary>
		/// Specifies "include" tag.
		/// </summary>
		Include,
		/// <summary>
		/// Specifies "remarks" tag.
		/// </summary>
		Remarks,
		/// <summary>
		/// Specifies "list" tag.
		/// </summary>
		List,
		/// <summary>
		/// Specifies "returns" tag.
		/// </summary>
		Returns,
	}
	#endregion

	#region INetNamespace
	/// <summary>
	/// Represents a .NET namespace.
	/// </summary>
	public interface INetNamespace
	{
		/// <summary>
		/// When implemented by a class, gets name or alias of the namespace.
		/// </summary>
		string GetName();
		/// <summary>
		/// When implemented by a class, gets or sets name of the namespace.
		/// </summary>
		string Namespace
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets alias of the namespace.
		/// </summary>
		string Alias
		{
			get;
			set;
		}
		/// <summary>
		/// Reserwed for internal use.
		/// </summary>
		bool System
		{
			get;
			set;
		}
	}
	#endregion

	#region IReflectionRepository
	/// <summary>
	/// Represents properties and methods to perform code completion functionality using reflection.
	/// </summary>
	public interface IReflectionRepository : ICodeCompletionRepository
	{
		/// <summary>
		/// When implemented by a class, adds specified namespace to the namespace list.
		/// </summary>
		/// <param name="nspace">Specifies name of namespace to add.</param>
		void RegisterNamespace(string nspace);
		/// <summary>
		/// When implemented by a class, removes specified namespace from the namespace list.
		/// </summary>
		/// <param name="nspace">Specifies name of namespace to remove.</param>
		/// <returns>True if succeed (namespace is present in the namespace list); otherwise false.</returns>
		bool UnregisterNamespace(string nspace);
		/// <summary>
		/// When implemented by a class, adds specified object for code completion to the object list.
		/// </summary>
		/// <param name="name">Specifies name of the object.</param>
		/// <param name="obj">Specifies object to register.</param>
		void RegisterObject(string name, object obj);
		/// <summary>
		/// When implemented by a class, removes specified object from the object list.
		/// </summary>
		/// <param name="name">Specifies name of object to remove.</param>
		/// <returns>True if succeed (object is present in the object list); otherwise false.</returns>
		bool UnregisterObject(string name);
		/// <summary>
		/// When implemented by a class, adds specified type for code completion to the type list.
		/// </summary>
		/// <param name="name">Specifies name of the type.</param>
		/// <param name="type">Specifies type to register.</param>
		void RegisterType(string name, Type type);
		/// <summary>
		/// When implemented by a class, adds specified type for code completion to the type list.
		/// </summary>
		/// <param name="name">Specifies name of the type.</param>
		/// <param name="type">Specifies type to register.</param>
		/// <param name="global">Specifies whether the type is global</param>
		void RegisterType(string name, Type type, bool global);
		/// <summary>
		/// When implemented by a class, removes specified type from the type list.
		/// </summary>
		/// <param name="name">Specifies name of type to remove.</param>
		/// <returns>True if succeed (type is present in the type list); otherwise false.</returns>
		bool UnregisterType(string name);
		/// <summary>
		/// When implemented by a class, adds specified assembly for code completion to the assembly list.
		/// </summary>
		/// <param name="assembly">Specifies registered assembly.</param>
		void RegisterAssembly(Assembly assembly);
		/// <summary>
		/// When implemented by a class, adds specified assembly for code completion to the assembly list.
		/// </summary>
		/// <param name="name">Specifies name of the assembly.</param>
		bool RegisterAssembly(string name);
		/// <summary>
		/// When implemented by a class, removes specified assembly from the assembly list.
		/// </summary>
		/// <param name="assembly">Specifies  assembly to remove.</param>
		/// <param name="removeReferences">Indicates whether all types from the specified assembly should be unregistered.</param>
		/// <returns>True if succeed (assembly is present in the assembly list); otherwise false.</returns>
		bool UnregisterAssembly(Assembly assembly, bool removeReferences);
		/// <summary>
		/// When implemented by a class, removes specified assembly from the assembly list.
		/// </summary>
		/// <param name="name">Specifies name of assembly to remove.</param>
		/// <param name="removeReferences">Indicates whether all types from the specified assembly should be unregistered.</param>
		/// <returns>True if succeed (assembly is present in the assembly list); otherwise false.</returns>
		bool UnregisterAssembly(string name, bool removeReferences);
		/// <summary>
		/// When implemented by a class, registers all assemlies from the current application domain.
		/// </summary>
		void RegisterAllAssemblies();
		/// <summary>
		/// When implemented by a class, registers some most frequently used assemblies.
		/// </summary>
		void RegisterDefaultAssemblies();
		/// <summary>
		/// When implemented by a class, disables type members from being shown in code completion windows.
		/// </summary>
		/// <param name="type">Specifies type which members will be disabled</param>
		void RestrictTypeMembers(Type type);
		/// <summary>
		/// When implemented by a class, re-enables type members from being shown in code completion windows.
		/// </summary>
		/// <param name="type">Specifies type which members will be re-enabled</param>
		void AllowTypeMembers(Type type);
		/// <summary>
		/// When implemented by a class, clears namespace list.
		/// </summary>
		void ClearNamespaces();
		/// <summary>
		/// When implemented by a class, clears object list.
		/// </summary>
		void ClearObjects();
		/// <summary>
		/// When implemented by a class, clears assembly list.
		/// </summary>
		void ClearAssemblies();
		/// <summary>
		/// When implemented by a class, clears type list.
		/// </summary>
		void ClearTypes();
		/// <summary>
		/// When implemented by a class, represents type list in a form of key-value pairs.
		/// </summary>
		Hashtable Types
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents object list in a form of key-value pairs.
		/// </summary>
		Hashtable Objects
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents assembly list.
		/// </summary>
		IList Assemblies
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents namespace list.
		/// </summary>
		IList Namespaces
		{
			get;
		}
	}
	#endregion
}
