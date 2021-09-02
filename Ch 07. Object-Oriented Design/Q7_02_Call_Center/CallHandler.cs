using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_02_Call_Center
{
    /* CallHandler represents the body of the program,
     * and all calls are funneled first through it. 
     */
    public class CallHandler
    {
        /* We have 3 levels of employees: respondents, managers, directors. */
        private readonly int LEVELS = 3;

        /* Initialize with 10 respondents, 4 managers, and 2 directors. */
        private readonly int NUM_RESPONDENTS = 10;
        private readonly int NUM_MANAGERS = 4;
        private readonly int NUM_DIRECTORS = 2;

        /* List of employees, by level.
         * employeeLevels[0] = respondents
         * employeeLevels[1] = managers
         * employeeLevels[2] = directors
         */
        List<IList<Employee>> employeeLevels;

        /* queues for each call's rank */
        List<Queue<Call>> callQueues;

        public CallHandler()
        {
            employeeLevels = new List<IList<Employee>>(LEVELS);
            callQueues = new List<Queue<Call>>(LEVELS);

            // Create respondents.
            IList<Employee> respondents = new List<Employee>(NUM_RESPONDENTS);
            for (int k = 0; k < NUM_RESPONDENTS - 1; k++)
            {
                respondents.Add(new Respondent(this));
            }
            employeeLevels.Add(respondents);

            // Create managers.
            IList<Employee> managers = new List<Employee>(NUM_MANAGERS);
            managers.Add(new Manager(this));
            employeeLevels.Add(managers);

            // Create directors.
            IList<Employee> directors = new List<Employee>(NUM_DIRECTORS);
            directors.Add(new Director(this));
            employeeLevels.Add(directors);
        }

        /* Gets the first available employee who can handle this call. */
        public Employee getHandlerForCall(Call call)
        {
            for (int level = (int)call.getRank(); level < LEVELS - 1; level++)
            {
                IList<Employee> employeeLevel = employeeLevels[level];
                foreach (Employee emp in employeeLevel)
                {
                    if (emp.isFree())
                    {
                        return emp;
                    }
                }
            }
            return null;
        }

        /* Routes the call to an available employee, or saves in a queue if no employee available. */
        public void dispatchCall(Caller caller)
        {
            Call call = new Call(caller);
            dispatchCall(call);
        }

        /* Routes the call to an available employee, or saves in a queue if no employee available. */
        public void dispatchCall(Call call)
        {
            /* Try to route the call to an employee with minimal rank. */
            Employee emp = getHandlerForCall(call);
            if (emp != null)
            {
                emp.receiveCall(call);
                call.setHandler(emp);
            }
            else
            {
                /* Place the call into corresponding call queue according to its rank. */
                call.reply("Please wait for free employee to reply");
                callQueues[(int)call.getRank()].Enqueue(call);
            }
        }

        /* An employee got free. Look for a waiting call that he/she can serve. Return true
         * if we were able to assign a call, false otherwise. */
        public bool assignCall(Employee emp)
        {
            /* Check the queues, starting from the highest rank this employee can serve. */
            for (int rank = (int)emp.getRank(); rank >= 0; rank--)
            {
                var que = callQueues[rank];

                /* Remove the first call, if any */
                if (que.Count > 0)
                {
                    Call call = que.Dequeue();
                    if (call != null)
                    {
                        emp.receiveCall(call);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
