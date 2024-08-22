import React from 'react';

const TicketHistory = ({ tickets }) => (
  <div className="ticket-history">
    <h3>Ticket History</h3>
    {tickets.map((ticket, index) => (
      <div key={index} className="ticket-item">
        <div className="ticket-header">
          <h4>{ticket.title}</h4>
          <span>{ticket.date} • {ticket.time} • <span className={`status ${ticket.status.toLowerCase()}`}>{ticket.status}</span></span>
        </div>
        <p>{ticket.description}</p>
        <button className="view-ticket-btn">View Ticket</button>
      </div>
    ))}
  </div>
);

export default TicketHistory;
