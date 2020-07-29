import React from 'react';
import { Modal } from 'react-bootstrap';
import { Button } from '../index';

// import { Container } from './styles';

interface IModalConfirm {
  togle: boolean;
  setTogle(arg: any): void;
  textHeader: string;
}

const ModalConfirm: React.FC<IModalConfirm> = ({
  togle,
  setTogle,
  children,
  textHeader,
}) => {
  return (
    <Modal show={togle} onHide={setTogle}>
      <Modal.Header closeButton>
        <Modal.Title>{textHeader}</Modal.Title>
      </Modal.Header>
      <Modal.Body>{children}</Modal.Body>
      <Modal.Footer>
        <Button onClick={setTogle}>Confirm</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalConfirm;
