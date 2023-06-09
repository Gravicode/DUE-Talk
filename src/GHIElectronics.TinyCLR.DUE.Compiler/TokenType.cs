﻿// Decompiled with JetBrains decompiler
// Type: GHIElectronics.TinyCLR.DUE.Compiler.TokenType
// Assembly: GHIElectronics.TinyCLR.DUE.Compiler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4604F13D-6F7E-4BF6-9153-3AEAE79C81C3
// Assembly location: D:\experiment\BMC.AirQuality\src\NF.AirQuality\bin\Debug\GHIElectronics.TinyCLR.DUE.Compiler.dll

namespace GHIElectronics.TinyCLR.DUE.Compiler
{
  public enum TokenType
  {
    None,
    Sof,
    Eof,
    Int,
    Float,
    String,
    ArrayLiteral,
    ByteArray,
    Identifier,
    Plus,
    Minus,
    Times,
    Divide,
    Mod,
    Shl,
    Shr,
    Assign,
    Eq,
    Neq,
    Lt,
    Leq,
    Gt,
    Geq,
    Not,
    And,
    Or,
    BitAnd,
    BitOr,
    BitXor,
    BitNot,
    Indent,
    Outdent,
    Comma,
    SemiColon,
    Colon,
    LParen,
    RParen,
    LBrace,
    RBrace,
    LBracket,
    RBracket,
    VarDecl,
    ConstDecl,
    FuncDecl,
    Return,
    If,
    ElseIf,
    Else,
    While,
    Break,
    Continue,
    Array,
    Print,
    Cls,
    Len,
    Begin,
    End,
    BuiltIn,
    FullExpression,
    Error,
  }
}
