using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp : MonoBehaviour
{
    // OOP: Object-Oriented Programming
    // Encapsulation
    public class ClassExam
    {
        // Member Access Modifier
        int defVal;
        private int priVal;
        public int pubVal;

        // �Լ�, Function, Method
        // Getter, Setter
        public void SetPriVal(int _priVal)
        {
            if (_priVal > 10) return;
            priVal = _priVal;
        }

        public int GetPriVal()
        {
            if (priVal < 0) return 0;
            return priVal;
        }

        // Properties
        public int PriVal
        {
            get { return priVal; }
            set {
                if (value > 10) return;
                priVal = value;
            }
        }
        public int val { get; set; }
    }

    // ���(Inheritance)
    // Parent-Child, �θ�-�ڽ�
    // Super-Sub, ����-����
    // Base-Derived, �⺻-�Ļ�
    public class Parent {
        protected int parentVal;

        // ������(Contructor)
        public Parent()
        {
            Debug.Log("+++++ Parent Contructor");
        }
        public Parent(int _i)
        {

        }
        // �Ҹ���(Destructor)
        ~Parent()
        {
            Debug.Log("----- Parent Destructor");
        }

        public virtual void ParentFunc() {
            Debug.Log("parentVal: " + parentVal);
        }
    }


    // Abstract
    public abstract class AbstractParent
    {
        // Pure Virtual Class / Function
        public abstract void ParentFunc();
    }

    public class APChild : AbstractParent
    {
        public override void ParentFunc() { }
    }

    public abstract class Weapon
    {
        public void Reload() { }
        public abstract void Fire();
    }

    public interface IWeapon { }
    public interface IWeapon2 { }
    public class NewWeapon : IWeapon, IWeapon2
    {

    }

    public class Child : Parent {
        private int childVal;

        public Child()
        {
            //base.Parent();
            Debug.Log("+++++ Child Constructor");
        }
        ~Child()
        {
            Debug.Log("----- Child Destructor");
        }

        public void ChildFunc() {
            Debug.Log("childVal: " + childVal);
            ParentFunc();
            parentVal = 10;
        }
        // Function Overloading
        public void Func() { }
        public void Func(int _i) { }
        public void Func(int _i, float _f) { }
        public void Func(float _f) { }
        // Default Parameter
        public void DefFunc(int _i = 10)
        {
            Debug.Log("_i: " + _i);
        }

        // Function Overriding
        public override void ParentFunc()
        {
            Debug.Log("Child-ParentFunc");
        }
    }

    public class NewChild : Parent
    {
        public override void ParentFunc()
        {
            base.ParentFunc();
            Debug.Log("NewChild ParentFunc");
        }
    }

    private void Start()
    {
        ClassExam ce = new ClassExam();
        ce.SetPriVal(10);
        ce.PriVal = 100;

        Child child = new Child();
        child.ParentFunc();
        child.DefFunc();

        Debug.Log("=====================");
        // Polymophism(������)
        Parent parent = new Child();
        parent.ParentFunc();
        //((Child)parent).ParentFunc();
        //Child c = new Parent();
        //parent = new NewChild();
        //parent.ParentFunc();

        //AbstractParent ap = new AbstractParent();

        Parent p = new Parent();
        //Quaternion.Euler()
    }
}
