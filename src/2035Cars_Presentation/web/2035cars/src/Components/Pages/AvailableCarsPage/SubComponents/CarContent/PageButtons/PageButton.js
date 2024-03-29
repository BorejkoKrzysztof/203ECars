import React from 'react'
import styles from './PageButton.module.css'
import { IoIosArrowBack, IoIosArrowForward } from 'react-icons/io'
import { HiOutlineDotsHorizontal } from 'react-icons/hi'

function PageButton(props) {

  function RenderBeforePageButton() {
    return (
      <button className={styles.pageButton} onClick={() => {
        if (props.currentPage != 1) {
          const previousPageValue = props.currentPage - 1
          props.setPage(previousPageValue)
        }
      }}>
        <IoIosArrowBack />
      </button>
    )
  }

  function RenderPageButton(pageNumber) {
    return (
      <button className={pageNumber === props.currentPage ? `${styles.pageButton} ${styles.pageButtonLight}` : `${styles.pageButton}`} 
              onClick={() => {
                props.setPage(pageNumber)
              }}>
        {pageNumber}
      </button> 
    )
  }

  function RenderNextPageButton() {
    return (
      <button className={styles.pageButton} onClick={() => {
        if (props.currentPage != props.amountOfPages) {
          const nextPageValue = props.currentPage + 1
          props.setPage(nextPageValue)
        }
      }}>
        <IoIosArrowForward />
      </button>
    )
  }

  function RenderSetOfPagesButtons() {
    if (props.amountOfPages > 3)
    {
      return (
        <div className={styles.pageButtonContent}>
            <RenderBeforePageButton />
            {
              props.amountOfPages - props.currentPage < 3 ?
              <>
                {RenderPageButton(1)}
                <>
                  <HiOutlineDotsHorizontal className={styles.pageDots}/>
                </>
                {RenderPageButton(props.currentPage)}
                {/* {RenderPageButton(props.amountOfPages - 1)} */}
                {RenderPageButton(props.amountOfPages)}
              </>
              :
              <>
              {
                  props.currentPage < 3 ?
                  <>
                    {RenderPageButton(1)}
                    {RenderPageButton(2)}
                    {RenderPageButton(3)}
                  </>
                  :
                  <>
                    {RenderPageButton(props.currentPage - 2)}
                    {RenderPageButton(props.currentPage - 1)}
                    {RenderPageButton(props.currentPage)}
                  </>
              }
                <>
                  <HiOutlineDotsHorizontal className={styles.pageDots}/>
                </>
                {RenderPageButton(props.amountOfPages)}
              </>
            }
            <RenderNextPageButton />
        </div>
      )
    }

    switch (props.amountOfPages) {
      case 2:
        return (
          <div className={styles.pageButtonContent}>
            <RenderBeforePageButton />
            {RenderPageButton(1)}
            {RenderPageButton(2)}
            <RenderNextPageButton />
          </div>
        )
      case 3:
        return (
          <div className={styles.pageButtonContent}>
            <RenderBeforePageButton />
            {RenderPageButton(1)}
            {RenderPageButton(2)}
            {RenderPageButton(3)}
            <RenderNextPageButton />
          </div>
        )
    }
  }

  return (
    <div className={styles.pageButtonWrapper}>
        <RenderSetOfPagesButtons />
    </div>
  )
}

export default PageButton