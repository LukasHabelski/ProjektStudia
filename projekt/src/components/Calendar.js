import React, { useEffect, useState } from "react";
import "./Calendar.css";

function Calendar() {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    fetch("/api/Calendar")
      .then((response) => response.json())
      .then((data) => setTasks(data));
  }, []);

  return (
    <div className="calendar">
      <h2>Terminarz</h2>
      <ul>
        {tasks.map((task) => (
          <li key={task.id}>
            {task.title} - {task.date}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Calendar;
