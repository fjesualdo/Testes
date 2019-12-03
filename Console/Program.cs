using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ColecaoConjunto();
            //new FormatString();
            //new SobreCargaEqual();

            //new InstrucoesLambda();


            ExpressionInLINQ _expressionInLINQ = new ExpressionInLINQ();

            _expressionInLINQ.MultipleSelect();
            _expressionInLINQ.LINQQueryReturnsCollectionOfAnonymousObjects();
            _expressionInLINQ.LINQGroupByQuery01();
            _expressionInLINQ.LINQGroupByQuery02();
            _expressionInLINQ.LINQLeftOuterJoin01();
            _expressionInLINQ.LINQLeftOuterJoin02();
            _expressionInLINQ.Sorting();
            _expressionInLINQ.LINQInnerJoin();
            _expressionInLINQ.NestedQuery();
            _expressionInLINQ.WhereExtension();
            _expressionInLINQ.JoinOperator();
            _expressionInLINQ.GroupJoinQuery();
            _expressionInLINQ.SelectInQuery();
            _expressionInLINQ.All_Any_Operator();
            _expressionInLINQ.Contains_Aggregate_Average_SequenceEqual_operator();
            _expressionInLINQ.DefaultIfEmpty();
            _expressionInLINQ.OperatorDistinct();
            _expressionInLINQ.ExceptWithObject();
            _expressionInLINQ.IntersectInMethod();
            _expressionInLINQ.UnionOperator();

        }
    }
}