namespace Interpreter
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    public class Tokenizer
    {
        private string source;
        private List<Token> tokens = new List<Token>();

        private int start = 0;
        private int current = 0;
        private int line = 1;

        private static Dictionary<string, TokenType> keywords;
        static Tokenizer()
        {
            keywords = new Dictionary<string, TokenType>();
            keywords["and"] = TokenType.AND;
            keywords["class"] = TokenType.CLASS;
            keywords["else"] = TokenType.ELSE;
            keywords["false"] = TokenType.FALSE;
            keywords["for"] = TokenType.FOR;
            keywords["fun"] = TokenType.FUN;
            keywords["if"] = TokenType.IF;
            keywords["nil"] = TokenType.NIL;
            keywords["or"] = TokenType.OR;
            keywords["print"] = TokenType.PRINT;
            keywords["return"] = TokenType.RETURN;
            keywords["super"] = TokenType.SUPER;
            keywords["this"] = TokenType.THIS;
            keywords["true"] = TokenType.TRUE;
            keywords["var"] = TokenType.VAR;
            keywords["while"] = TokenType.WHILE;
        }

        public Tokenizer(string source)
        {
            this.source = source;
        }
        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                start = current;
                ScanToken();
            }

            tokens.Add(new Token(TokenType.EOF, "", null, line));
            return tokens;
        }
        private bool IsAtEnd()
        {
            return current >= source.Length;
        }
        private void ScanToken()
        {
            char c = Advance();
            switch (c)
            {
                case '(': AddToken(TokenType.LEFT_PAREN); break;
                case ')': AddToken(TokenType.RIGHT_PAREN); break;
                case '{': AddToken(TokenType.LEFT_BRACE); break;
                case '}': AddToken(TokenType.RIGHT_BRACE); break;
                case ',': AddToken(TokenType.COMMA); break;
                case '.': AddToken(TokenType.DOT); break;
                case '-': AddToken(TokenType.MINUS); break;
                case '+': AddToken(TokenType.PLUS); break;
                case ';': AddToken(TokenType.SEMICOLON); break;
                case '*': AddToken(TokenType.STAR); break;
                case '!': AddToken(Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG); break;
                case '=': AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL); break;
                case '<': AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS); break;
                case '>': AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER); break;
                case '/': // Double slash for comment ignore until the next line
                    if (Match('/'))
                    {
                        while (Peek() != '\n' && !IsAtEnd()) Advance();
                    }
                    else
                    {
                        AddToken(TokenType.SLASH);
                    }
                    break;
                // WhiteSpaces
                case ' ':
                case '\r':
                case '\t':
                    break;
                case '\n': line++; break;
                case '"': HandleString(); break;
                default:
                    if (IsDigit(c))
                    {
                        HandleNumber();
                    }
                    else if (IsAlpha(c))
                    {
                        HandleIdentifier();
                    }
                    else
                    {
                        Console.WriteLine("ERROR ScanToken Fail"); // TODO: Error Handling
                    }
                    break;
            }
        }
        private bool Match(char expected)
        {
            if (IsAtEnd()) return false;
            if (source[current] != expected) return false;
            current++;
            return true;
        }
        private char Peek()
        {
            if (IsAtEnd()) return '\0';
            return source[current];
        }
        private char PeekNext()
        {
            if (current + 1 >= source.Length) return '\0';
            return source[current + 1];
        }
        private char Advance()
        {
            char result = source[current];
            current++;
            return result;
        }
        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }
        private void AddToken(TokenType type, object literal)
        {
            Debug.Log(string.Format("TokenType: {0}", type));
            string text = source.Substring(start, current - start);
            tokens.Add(new Token(type, text, literal, line));
        }
        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        private bool IsAlpha(char c)
        {
            return (c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z' ||
                    c == '_');
        }
        private bool IsAlphaNumberic(char c)
        {
            return IsDigit(c) || IsAlpha(c);
        }

        private void HandleString()
        {
            while (Peek() != '"' && !IsAtEnd())
            {
                if (Peek() == '\n') line++;
                Advance();
            }

            if (IsAtEnd())
            {
                // ERROR Unterminated String
            }

            // Closing "
            Advance();
            // Not Include Quotes
            string value = source.Substring(start + 1, (current - start) - 1);
            AddToken(TokenType.STRING, value);
        }
        private void HandleNumber()
        {
            while (IsDigit(Peek()))
            {
                Advance();
            }
            if (Peek() == '.' && IsDigit(PeekNext()))
            {
                Advance();

                while (IsDigit(Peek())) Advance();
            }
            AddToken(TokenType.NUMBER, Convert.ToDouble(source.Substring(start, current - start)));
        }
        private void HandleIdentifier()
        {
            while (IsAlphaNumberic(Peek())) Advance();

            string text = source.Substring(start, current - start);
            TokenType type = TokenType.IDENTIFIER;
            if (keywords.ContainsKey(text))
            {
                type = keywords[text];
            }
            AddToken(type);
        }
    }
}
