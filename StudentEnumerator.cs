using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class StudentEnumerator : IEnumerator
    {
        private ArrayList _exams;
        private ArrayList _tests;

        private int _examsCounter = -1;
        private int _testsCounter = -1;

        public StudentEnumerator(ArrayList _exams, ArrayList _tests)
        {
            this._exams = _exams;
            this._tests = _tests;
        }

        public object Current
        {
            get
            {
                if (_examsCounter == -1 || _examsCounter >= _exams.Count || _testsCounter == -1 || _testsCounter >= _tests.Count)
                    throw new ArgumentException();
                
                if (((Exam)_exams[_examsCounter])._subjectName == ((Test)_tests[_testsCounter])._subjectName)
                {
                    return _exams[_examsCounter]; 
                }
            }
        }

        public bool MoveNext()
        {
            if (_exams.Count < _tests.Count)
            {
                _examsCounter++;
                return (_examsCounter >= _exams.Count);
            }
            else if (_exams.Count > _tests.Count)
            {
                _testsCounter++;
                return (_testsCounter >= _tests.Count);
            }
            else
            {
                _examsCounter++;
                return (_examsCounter >= _exams.Count);
            }
        }

        public void Reset()
        {
            _examsCounter = -1;
            _testsCounter = -1;
        }
    }
}
