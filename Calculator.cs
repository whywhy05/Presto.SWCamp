using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Operators 
namespace WindowsFormsApp1
{


    public enum Operators          //enum 함수 사용
    {
        Add,
        Sub,
        Multi,
        Div,
        Result

    }

    //public enum Operators{Add,Sub,Multi,Div,Result}        //덧셈, 뺼셈, 곱셈,나눗셈 변수 지정.

    public partial class Calculator : Form
    {

        public int Result = 0;      //Result =0 ;; 
        public bool isNewNum = true;     //계산값을 나타내는 스크린
        public bool isStartNum = true;   // 결과값을 나타내는 스크린.
        public Operators Opt = Operators.Add;
        public Operators lastOperator = Operators.Add;

        public Calculator()
        {
            InitializeComponent();

            if (lastOperator == Operators.Add)
            {

            }
            else if (lastOperator == Operators.Sub)
            {

            }
            else if (lastOperator == Operators.Multi)
            {

            }
            else if (lastOperator == Operators.Div)
            {

            }
            else if (lastOperator == Operators.Result) ;
        }
       
        //int number1;
    

     private void NumButton_Click(object sender, EventArgs e)
     {
        Button numButton = (Button)sender; 
        SetNum(numButton.Text);       //지정
     }

        public void SetNum(String number)
        {
            if (isNewNum)     //조건문(isNewNum)
            {
                if (isStartNum)
                {
                    NumberScreen.Text = number;   //수식값을 초기화 .
                }
                else
                {
                    NumberScreen.Text += number;  // 두값을더해 나타낸다.
                }

                ResultScreen.Text = number; //결과 값을 나타낸다.
                isNewNum = false;
                isStartNum = false;
            }
            else
            {
                if (ResultScreen.Text == "0")     //결과값이 0 일때 
                {
                    NumberScreen.Text = number;  //수식값 = nub
                    ResultScreen.Text = number;  // 결과값 = nub
                }
                else                        // 0이 아닐때.
                {
                    NumberScreen.Text = NumberScreen.Text + number;      //수식창= 수식창   +nub
                    ResultScreen.Text = ResultScreen.Text + number;      //결과창 = 결과창 + nub
                }

            }
        }


     private void Opt_Click(object sender, EventArgs e)
     {
        if (isNewNum == false)
        {
            int num = int.Parse(ResultScreen.Text);              //변수num 지정.
            if (Opt == Operators.Add)          //Opt == operators ?
                Result += num;                 //결과값을 변수에저장된값과 더함
            else if (Opt == Operators.Sub)
            {
                Result -= num;
            }
            else if (Opt == Operators.Multi)
            {
                Result *= num;
            }
            else if (Opt == Operators.Div)
            {
                Result /= num;
            }
            else if (Opt == Operators.Result)
            {
                NumberScreen.Text = Result.ToString();      //정수를 문자로 바꿔줌 - 수식값
            }
            ResultScreen.Text = Result.ToString();         //정수를 문자로 바꿔줌 - 결과값
            isNewNum = true;
        }


        Button optButton = (Button)sender;
        if (optButton.Text == "+")//+버튼을 누를때
        {
            Opt = Operators.Add; // 더한다
            NumberScreen.Text += "+"; //수식창에 + 출력
        }
        else if (optButton.Text == "-") //- 을 눌릴때
        {
            Opt = Operators.Sub;      //뺄셈
            NumberScreen.Text += "-"; //수식창에 - 출력
        }
        else if (optButton.Text == "*")
        {
            Opt = Operators.Multi;     //곱셈
            NumberScreen.Text += "*";     //수식창에 * 출력
        }
        else if (optButton.Text == "/")
        {
            Opt = Operators.Div;
            NumberScreen.Text += "/";
        }
        else if (optButton.Text == "=")    //
        {
            Result = 0;          //0으로 초기화
            isNewNum = true;
            isStartNum = true;

            Opt = Operators.Add;    //입력하기전의상태로 돌려줌.

            NumberScreen.Text = "0";  //수식창 초기화.
        }
     }

     private void clear_Click(object sender, EventArgs e)
     {
        Clear();
     }
     public void Clear()
     {
        Result = 0;        //초기화 과정
        isNewNum = true;
        isStartNum = true;
        Opt = Operators.Add;

        NumberScreen.Text = "0";
        ResultScreen.Text = "0";
     }
    }
}