// 주석 (Comment) : 프로그램에 영향을 미치지 않는 텍스트
// 개발자가 소스코드의 의도를 설명하하기 위해 사용

// 한줄 주석 : 한 라인의 // 뒤의 텍스트는 주석 처리
/* 범위 주석 :
   여러 라인 또는 한 라인중의 일부 범위에 주석 처리 
*/

///문서화주석 태그 유형
///summary : 일반 설명
///param : 함수의 매개변수에 대한 설명, name 항목에 문자열을 대입하여 어떤 매개변수에
///대한 설명인지 지정
///returns : 함수의 반환값에 대한 설명

/// <summary>
/// 문서화 주석 : 소스코드에는 영향을 미치지 않지만, IDE에서 해당 요소에 대한 설명을
///출력해줄때 인지하여 보여줌
///문서화 주석은 일반 주석 내용은 IDE에서 무시하나, 꺽쇠 안의 "태그"를 이용하여
///해당 요소가 어디에 대한 설명인지 명시할 수 있음.
/// </summary>
/// 
///<summary>
///사용자의 입력을 int로 변환해주는 함수.
///</summary>
///<param name="index">몇번째 입력인지?<br/>예시: 0번째 정수를 입력하세요 : </param>
///<returns>콘솔에서 입력한 입력값을 정수로 반환</returns>

using System; // using 지시문 : 이 .cs 파일에서 특정 namespaced의 요소를 참고가능하도록함
                /*이 파일에서는 닷넷 프레임워크에 포함된 System이라는 namespace안의
                기능을 사용할 것이다 라는 의미*/

//namespace 선언문 : 브레이슬릭{} 내의 요소는 이 namespace 안에 포함된 것임.
namespace InputOutput // 다른 namespace에서 이 안의 요소를 참조하기 위해서는 
{                       //using 지시문을 통해 참조를 명시할 필요가 있음.
    /* 브레이슬릿{} : 중괄호 {}로 열고 닫아서 그 안의 내용을 하나의 블록으로 처리.
     블록 앞에는 반드시 해당 블록의 종류에 대한 선언이 필요하며, 
     예외로 메소드 내에서는 이름 없이 블록만 처리가 가능*/

    //클래스 : 객체지향형 언어인 C#에서 모듈을 구성하는 기본 단위인 객체를 정의함.
    // 
    internal class MymainProgram // 
    {
        //Main 메소드(함수) : C#으로 작성된 실행 가능한 프로그램의 진입점.
        //프로그램으로 실행 시킬 소스 코드는 반드시 1개의 Main 메소드를 가져야 함.
        static void Main(string[] args)
        {
            /* C#에서 콘솔에 출력하는 기능은 Console 클래스 내의 WriteLine 메소드를
               호출하여 할 수 있음. */
            //Console.Write : 문자열 출력
            //Console.WriteLine : 문자열 출력과 뒤에 줄 추가
            Console.Write("Hi, ");
            Console.WriteLine("Hello World!");
            Console.WriteLine("안녕하세요.");
            Console.Write("이성준 입니다.");
            Console.WriteLine(); // WriteLine 메소드는 매개변수가 없을경우 줄바꿈만.
            Console.Write("환영 합니다.");
            Console.WriteLine("만나서 반갑습니다.");
            Console.WriteLine("☆★잘 부탁드립니다.★☆");

            // 콘솔에서 키보드 입력을 받는 기능도 Console클래스에 포함되어 있음.
            // Console.ReadLine() : 키보드의 줄바꿈(Enter)키의 입력이 들어오면
            // 입력된 값을 받음.
            Console.ReadLine();//엔터 입력이 들어올때까지 대기
            Console.WriteLine("엔터키를 입력하셨습니다.");

            Console.Read();//문자 입력이 있을 시 까지 대기
            Console.WriteLine("문자 키를 입력하였습니다.");


            Console.ReadKey(); // 아무 키나 입력이 있을 때 까지 대기 
            Console.WriteLine("키보드 입력을 하였습니다.");


        }
    }
}
